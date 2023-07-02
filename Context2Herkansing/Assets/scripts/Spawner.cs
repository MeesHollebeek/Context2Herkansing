using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plus;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Spawning());
        
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Instantiate(plus, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator Spawning()
    {
        yield return new WaitForSeconds(10);
        

        StartCoroutine(Spawning());


    }
}
