using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepForm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(0.62877f, 1.346807f, 0.04408419f);

        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
