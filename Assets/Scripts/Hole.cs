using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
    [Header("Physics related")]
    [SerializeField] Vector2 myPosition;
    [SerializeField] Vector2 velocity;
    [SerializeField] Vector2 acceleration;
    bool stop=false;

    [Header("Gravitational Force")]
    [SerializeField]  float myMass = 2;
    [SerializeField] public float otherMass = 10;
    [SerializeField] public Transform otherObj;
    Vector2 fGravitacional;

    private void Start() {
        
        myPosition = transform.position;
    }

    private void Update() {
        // Draw vectors

        //acceleration.DrawVector(myPosition, Color.blue);
        //velocity.DrawVector(myPosition, Color.green);
        //myPosition.DrawVector(Color.red);

        // Calculate and update position
        if(!stop)UpdatePosition();
        transform.position = new Vector3(myPosition.x, myPosition.y);
    }

    public void UpdatePosition() {
        // Calculate the distance and direction for the gravity force
        Vector2 gravityDirection = otherObj.position - transform.position;
        float distance = gravityDirection.magnitude;
        gravityDirection = gravityDirection.normalized;

        // Calculate the gravity force
        if (distance > 0.1) fGravitacional = gravityDirection * (otherMass * myMass / distance * distance);
        else acceleration = gravityDirection;

        // Calculate new acceleration, velocity and position
        acceleration = ApplyForce(fGravitacional, myMass);
        velocity = velocity + acceleration * Time.deltaTime;
        myPosition = myPosition + velocity * Time.deltaTime;
    }

    Vector2 ApplyForce(Vector2 force, float mass) {
        return force * (1 / mass);
    }
    public void NewAcelerationVelo(Vector3 ace, Vector3 velo) {
        acceleration = ace;
        velocity = velo;
    }
    
}
