using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTarget : MonoBehaviour    
{
    [SerializeField] float myMass;
    Hole hole;
    LookAt look;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            look = collision.GetComponent<LookAt>();
            hole = collision.GetComponent<Hole>();
            hole.otherMass = myMass;
            hole.otherObj = gameObject.transform;
            look.target= gameObject.transform;
        }
    }
}
