using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBuilding : MonoBehaviour
{
  //  public GameObject Balance;

    private void Start()
    {
      //  Balance = GameObject.FindGameObjectWithTag("WipWap");

    }

    void OnMouseDown()
    {
       // ValueForBalance script = Balance.GetComponent<ValueForBalance>();


        
          //  script.Points = script.Points - 1;
        // 1 moet de tegenovergestelde value zijn die het gebouw bij of af haald

        //hier moet nog stukje komen dat de occupied space niet meer occupied is of ik kan het doen met oncollider leave
            Debug.Log("removed");
        Destroy(gameObject);
    }
}
