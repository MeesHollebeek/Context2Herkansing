using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBuilding : MonoBehaviour
{
    public GameObject ClearSpawnpoint;

    private void Update()
    {
      ClearSpawnpoint = GameObject.FindGameObjectWithTag("Occupied");

    }

    void OnMouseDown()
    {
       // transform.position = new Vector3 (0, 0 * Time.deltaTime, 0);

        Debug.Log("removed");

        StartCoroutine(Removing());
    }

    public IEnumerator Removing()
    {
        yield return new WaitForSeconds(.01f);

        Destroy(gameObject);

        ClearSpawnpoint.tag = "SpawnPoint";
    }
}
