using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // An array of prefabs to spawn
    public float spawnInterval = 2.0f; // Interval between spawns in seconds
    public Transform spawnLineStart; // Starting point of the spawn line
    public Transform spawnLineEnd; // Ending point of the spawn line
    private float timeSinceLastSpawn = 0.0f;

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObject();
            timeSinceLastSpawn = 0.0f;
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = Vector3.Lerp(spawnLineStart.position, spawnLineEnd.position, Random.value);
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject newObject = Instantiate(objectsToSpawn[randomIndex], spawnPosition, Quaternion.identity);
        newObject.transform.rotation = Quaternion.Euler(0, 90, 0); // Rotate the object by 90 degrees around the y-axis
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(spawnLineStart.position, spawnLineEnd.position);
    }
}
