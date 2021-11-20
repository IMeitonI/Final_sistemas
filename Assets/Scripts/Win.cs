using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Win : MonoBehaviour
{
    [SerializeField]GameObject winUI;
  
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Ganaste");
            collision.gameObject.SetActive(false);
            winUI.SetActive(true);
        }
    }
}
