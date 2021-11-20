using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    Vector2 newWorldPos;
    Vector2 velocity, acceleration;
    [SerializeField] float speed;
    [SerializeField] bool followAcele;
    [SerializeField] public Transform target;
    // Update is called once per frame
    void Update() {

        Look(target);
    }
    private Vector2 GetWorldMousePosition() {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        return worldPos; ;
    }
    private void RotateZ(float radians) {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }

    void Look(Transform worlPosition) {
        Vector2 draw =new Vector2(worlPosition.position.x,worlPosition.position.y);
        draw.Set(draw.x - transform.position.x, draw.y -transform.position.y);
        draw.Normalize();
        float angulo = Mathf.Atan2(draw.y, draw.x);
        
        RotateZ(angulo);
    }

}
