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


        //boven 0
        if (transform.rotation.x * 100 < Points && !belowzero)
        {
            angle = 0.01f;
        }

        if (transform.rotation.x * 100 > Points && !belowzero)
        {
            angle = -0.01f;
        }

        //onder 0
        if (transform.rotation.x * 100 > Points && belowzero)
        {
            angle = -0.01f;
        }

        if (transform.rotation.x * 100 < Points && belowzero)
        {
            angle = 0.01f;
        }

        //set to 0 when arrived
        if (transform.rotation.x * 100 > Points - 0.3 && transform.rotation.x * 100 < Points + 0.3)
        {
            angle = 0f;
        }


       // Debug.Log(transform.rotation.x);
    }
}
