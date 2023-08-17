using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    public GameObject plus;
    public GameObject Minus;

    public float SpacesOccupied;


    public void SpawnerPLusButton()
    {
        if(SpacesOccupied < 9)
        {
            Instantiate(plus, transform.position, Quaternion.identity);
        }
       



    }

    public void SpawnerMinusButton()
    {
        if (SpacesOccupied < 9)
        {
            Instantiate(Minus, transform.position, Quaternion.identity);
        }
       



    }
}
