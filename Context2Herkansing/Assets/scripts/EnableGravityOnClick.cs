using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGravityOnClick : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGravityEnabled;
    private bool isClickable;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true; // Disable movement

        isGravityEnabled = false;
        isClickable = true; // Enable clicking
    }

    private void OnMouseDown()
    {
        if (isClickable)
        {
            isGravityEnabled = !isGravityEnabled;
            rb.useGravity = isGravityEnabled;
            rb.isKinematic = !isGravityEnabled; // Enable movement if gravity is enabled

            isClickable = false; // Disable further clicking
        }
    }
}
