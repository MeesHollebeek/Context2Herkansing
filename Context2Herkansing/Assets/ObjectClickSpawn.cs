using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickSpawn : MonoBehaviour
{
    public GameObject spawnableObject; // Assign this in the Inspector
    public LayerMask clickableLayer;   // Assign the specific layer in the Inspector

    private void Update()
    {
        // Check for mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the clickable object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer.value) && hit.collider.gameObject == gameObject)
            {
                // Instantiate the spawnable object at the clicked position
                Instantiate(spawnableObject, hit.point, Quaternion.identity);
            }
        }
    }
}