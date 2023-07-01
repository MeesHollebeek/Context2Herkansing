using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueForBalance : MonoBehaviour
{
    private Vector3 TheRotation;
    public float angle;
    public float Points;

    private bool belowzero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(TheRotation);

        TheRotation = new Vector3(angle, 0, 0);

        if (Points >= 0)
        {
            belowzero = false;
        }
        if (Points < 0)
        {
            belowzero = true;
        }

        if (transform.rotation.x * 100 < Points && !belowzero)
        {
            angle = 0.01f;
        }

        if (transform.rotation.x * 100 >= Points && !belowzero)
        {
            angle = 0f;
        }

        if (transform.rotation.x * 100 > Points && belowzero)
        {
            angle = -0.01f;
        }

        if (transform.rotation.x * 100 <= Points && belowzero)
        {
            angle = 0f;
        }


        Debug.Log(transform.rotation.x);
    }
}
