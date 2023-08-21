using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteSpawn : MonoBehaviour
{
    public GameObject[] satellitePrefabs;  // Array of satellite prefabs
    public int numberOfSatellites = 5;  // Number of satellites to spawn
    public float minOrbitRadius = 5f;  // Minimum radius of the satellite's orbit
    public float maxOrbitRadius = 10f;  // Maximum radius of the satellite's orbit
    public float orbitSpeedValue = 1f;  // Speed at which the satellites orbit
    public Vector2 minRotationSpeedRange = new Vector2(1f, 5f);  // Minimum and maximum rotation speed range on each axis
    public Vector2 maxRotationSpeedRange = new Vector2(5f, 10f);

    private void Start()
    {
        SpawnSatellites();
    }

    private void SpawnSatellites()
    {
        for (int i = 0; i < numberOfSatellites; i++)
        {
            // Generate random angles for each axis
            float angleX = Random.Range(0f, 360f);
            float angleY = Random.Range(0f, 360f);
            float angleZ = Random.Range(0f, 360f);

            // Calculate a random orbit radius within the given range
            float orbitRadiusValue = Random.Range(minOrbitRadius, maxOrbitRadius);

            // Calculate the spawn position based on the random angles and orbit radius
            Vector3 spawnPosition = transform.position +
                Quaternion.Euler(angleX, angleY, angleZ) * (Vector3.forward * orbitRadiusValue);

            // Select a random satellite prefab from the array
            GameObject satellitePrefab = satellitePrefabs[Random.Range(0, satellitePrefabs.Length)];

            // Instantiate a satellite at the spawn position and set it to orbit the Earth
            GameObject satellite = Instantiate(satellitePrefab, spawnPosition, Quaternion.identity);
            satellite.transform.SetParent(transform);  // Set the Earth as the parent of the satellite

            // Add a script to the satellite to control its orbit and rotation
            SatelliteController satelliteController = satellite.AddComponent<SatelliteController>();
            satelliteController.orbitCenterPosition = transform.position;
            satelliteController.orbitRadiusValue = orbitRadiusValue;
            satelliteController.orbitSpeedValue = orbitSpeedValue;

            // Generate random rotation speed values within the given range
            float rotationSpeedX = Random.Range(minRotationSpeedRange.x, maxRotationSpeedRange.x);
            float rotationSpeedY = Random.Range(minRotationSpeedRange.y, maxRotationSpeedRange.y);
            float rotationSpeedZ = Random.Range(minRotationSpeedRange.x, maxRotationSpeedRange.x);
            satelliteController.rotationSpeedValue = new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ);

            // Set the start angles for the satellite's orbit
            satelliteController.SetStartAngles(new Vector3(angleX, angleY, angleZ));
        }
    }
}