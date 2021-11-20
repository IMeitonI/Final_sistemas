using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveR : MonoBehaviour
{
    [SerializeField] Resorte resorte;
    private void OnMouseDrag() {
        resorte.enabled = true;
    }
}
