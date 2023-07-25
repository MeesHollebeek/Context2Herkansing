using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject plus;


    public void SpawnerButton()
    {
        Instantiate(plus, transform.position, Quaternion.identity);



    }
}
