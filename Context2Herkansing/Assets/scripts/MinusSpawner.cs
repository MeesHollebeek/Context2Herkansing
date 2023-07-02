using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusSpawner : MonoBehaviour
{
    public GameObject minus;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Spawning());

    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            Instantiate(minus, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator Spawning()
    {
        yield return new WaitForSeconds(10);


        StartCoroutine(Spawning());


    }
}
