using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resorte : MonoBehaviour {
    [Header("World")]
    [SerializeField]
    private float gravity = -9.8f;

    [Header("Spring force terms")]
    [SerializeField]
    private float k = 0.1f;
     private float restLength = 0;
    float x;

    [Header("Object related")]
    [SerializeField]
    private float mass = 1;
    int init=0;
    [SerializeField] float maxX=2;
    public Vector3 acceleration;
    public Vector3 velocity;
    public Vector3 springForce;
    Vector3 worldPos;
    private bool isGrabbing = false;

     void Start() {
        restLength = transform.localPosition.magnitude;
     }

     void Update() {
        if (HandleUserGrab()|| init==0) return;

        // Calculate spring force
         x = transform.localPosition.magnitude - restLength;
        Vector3 springForceDir = transform.localPosition.normalized;
        
        springForce = -k * x * springForceDir;
        Debug.DrawLine(transform.position, springForce);
       // springForce.Draw(transform.position, Color.blue);
        
        // Apply forces
        acceleration = springForce / mass; // F = m*a -> F/m = a
        acceleration += Vector3.up * gravity; // Fw = mg -> a = Fw / m -> mg / m = g

        // Update velocity and position
        velocity += acceleration * Time.deltaTime;
        velocity *= 0.99f;
        
        ConstrainLength(0.5f, 5);
        transform.localPosition += velocity * Time.deltaTime;
    }


    private bool HandleUserGrab() // True if doing some grabbing stuff
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = GetWorldMousePosition(); mousePos.z = 0;
            if ((transform.position - mousePos).magnitude <= transform.localScale.x) // Assuming the sprite is a circle of radius 1
            {
                isGrabbing = true;
                transform.position = mousePos;
                velocity *= 0;
                init = 1;
                return true;
            }
        } else if (isGrabbing && Input.GetMouseButton(0)) {
            Vector3 mousePos = GetWorldMousePosition(); mousePos.z = 0;
            transform.position = mousePos;
            velocity *= 0;
            init = 1;
            return true;
        } else if (isGrabbing && Input.GetMouseButtonUp(0)) {
            isGrabbing = false;
        }

        return false;
    }

    private Vector3 GetWorldMousePosition() {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
         worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        MaxX();
        return worldPos;
    }

    private void ConstrainLength(float minLength, float maxLength) {
        var dir = transform.localPosition;
        
        var d = dir.magnitude;

        // Is it too short?
        if (d < minLength) {
            dir.Normalize();
            dir *= minLength;

            // Reset location and stop from moving (not realistic physics)
            transform.localPosition = dir;
            velocity *= 0;
        } else if (d > maxLength)  // Is it too long?
          {
            dir.Normalize();
            dir *= maxLength;

            // Reset location and stop from moving (not realistic physics)
            transform.localPosition = dir;
            velocity *= 0;
        }
    }

    void MaxX() {
        if (worldPos.x >= maxX) {
            worldPos.x = 1;
        } else if (worldPos.x <= -maxX) {
            worldPos.x = -1;
        }
    }
    

}
