using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteController : MonoBehaviour
{
    public Vector3 orbitCenterPosition;  // Center position of the orbit
    public float orbitRadiusValue = 5f;  // Radius of the satellite's orbit
    public float orbitSpeedValue = 1f;  // Speed at which the satellite orbits
    public Vector3 rotationSpeedValue = new Vector3(1f, 1f, 1f);  // Speed at which the satellite rotates on each axis

    private Vector3 startAngles;  // Starting angles around the X, Y, and Z axes

    private void Update()
    {
        // Calculate the target position based on the current orbit center, radius, and angles
        float angleX = startAngles.x + orbitSpeedValue * Time.time;
        float angleY = startAngles.y + orbitSpeedValue * Time.time;
        float angleZ = startAngles.z + orbitSpeedValue * Time.time;
        Vector3 targetPosition = orbitCenterPosition +
            Quaternion.Euler(angleX, angleY, angleZ) * (Vector3.forward * orbitRadiusValue);

        // Orbit around the target position
        transform.position = targetPosition;

        // Rotate the satellite around its own axis on each axis
        transform.Rotate(Vector3.up, rotationSpeedValue.x * Time.deltaTime);
        transform.Rotate(Vector3.right, rotationSpeedValue.y * Time.deltaTime);
        transform.Rotate(Vector3.forward, rotationSpeedValue.z * Time.deltaTime);
    }

    public void SetStartAngles(Vector3 angles)
    {
        startAngles = angles;
    }
}