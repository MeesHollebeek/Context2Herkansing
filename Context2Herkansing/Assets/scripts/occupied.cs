using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class occupied : MonoBehaviour
{
    public GameObject Building;

    void Update()
    {
        Building = GameObject.FindGameObjectWithTag("Placing");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Placing") || other.gameObject.CompareTag("Placing"))
        {
            tag = "Occupied";
            Building.tag = "Placed";
            Debug.Log("this");
        }
    }

}
