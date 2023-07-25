using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class occupied : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("plus"))
        {
            tag = "Occupied";
        }
    }
}
