using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parenting : MonoBehaviour
{
    public GameObject Building;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Building = GameObject.FindGameObjectWithTag("Placing");

        Building.transform.SetParent(this.transform);

    }
}
