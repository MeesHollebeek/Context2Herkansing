using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationFinder : MonoBehaviour
{
    public GameObject SpawnPoint;
    public bool placed = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Removing());
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        if(!placed)
        {
            transform.position = SpawnPoint.transform.position;
        }
           
        if (transform.position.x == SpawnPoint.transform.position.x)
        {
          placed = true;
        }

    }

    public IEnumerator Removing()
    {
        yield return new WaitForSeconds(0.1f);



        if (gameObject.tag == "Placing")
        {
             Destroy(gameObject);
        }
    }
}
