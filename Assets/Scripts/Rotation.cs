using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [Range(0, 5)] [SerializeField] float amplitudX, amplitudY;
    [Range(0, 15)] [SerializeField] float frecuenciaX, frecuenciaY;

    private void Start() {
    
    }
    private void Update() {
        Oscilacion();
    }
    void Oscilacion() {
        transform.position = new Vector3(  amplitudX * Mathf.Cos(frecuenciaX * Time.time),
        
        amplitudY * Mathf.Sin(frecuenciaY * Time.time)+2, transform.position.z);
    }
}
