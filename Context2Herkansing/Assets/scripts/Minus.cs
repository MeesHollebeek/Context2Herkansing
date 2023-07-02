using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minus : MonoBehaviour
{
    public GameObject Balance;

    private void Start()
    {
        Balance = GameObject.FindGameObjectWithTag("WipWap");

    }

    void OnTriggerEnter(Collider other)
    {
        ValueForBalance script = Balance.GetComponent<ValueForBalance>();

        if (other.gameObject.CompareTag("WipWap"))
        {
            script.Points = script.Points - 1;
            Debug.Log("HIT");
        }
    }
}
