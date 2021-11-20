using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    Resorte resorte;
    Hole hole;
    int i;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (i == 1) {
            resorte = collision.gameObject.GetComponent<Resorte>();
            hole = collision.gameObject.GetComponent<Hole>();
            hole.enabled = true;
            hole.NewAcelerationVelo(resorte.acceleration, resorte.velocity);
           
            resorte.enabled = false;
            gameObject.SetActive(false);
        } else if (i == 0) {
            i = 1;
           
        } 

    }
}
