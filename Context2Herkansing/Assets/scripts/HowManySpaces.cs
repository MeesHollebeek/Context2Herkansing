using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowManySpaces : MonoBehaviour
{
    public SpawnButton SpawnScript;
    public bool BeenOccupied = false;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Occupied" && !BeenOccupied)
        {
            SpawnScript.SpacesOccupied++;
            BeenOccupied = true;
            Debug.Log("+!");
        }

        if (gameObject.tag == "SpawnPoint" && BeenOccupied)
        {
            SpawnScript.SpacesOccupied--;
            BeenOccupied = false;
        }
    }
}
