using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    public GameObject plus;
    public GameObject Minus;


    public void SpawnerPLusButton()
    {
        Instantiate(plus, transform.position, Quaternion.identity);



    }

    public void SpawnerMinusButton()
    {
        Instantiate(Minus, transform.position, Quaternion.identity);



    }
}
