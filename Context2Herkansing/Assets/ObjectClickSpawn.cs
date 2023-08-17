using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickSpawn : MonoBehaviour
{
    private GameObject selectedObject; // The currently selected object
    public LayerMask clickableLayer;   // Assign the specific layer in the Inspector
    public GameObject particleSystemPrefab; // Assign the Particle System prefab in the Inspector

    // List of spawnable objects to assign in the Inspector
    public List<GameObject> spawnableObjects = new List<GameObject>();

    void Update()
    {
        // Check for mouse button click
        if (Input.GetMouseButtonDown(0) && selectedObject != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the clickable object
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer.value) && hit.collider.gameObject == gameObject)
            {
                // Instantiate the selected object at the clicked position
                GameObject spawnedObject = Instantiate(selectedObject, hit.point, Quaternion.identity);

                // Instantiate the particle system at the same position
                Instantiate(particleSystemPrefab, hit.point, Quaternion.identity);
            }
        }
    }

    // Call this method to set the selected object from your menu
    public void SetSelectedObject(int objectIndex)
    {
        if (objectIndex >= 0 && objectIndex < spawnableObjects.Count)
        {
            selectedObject = spawnableObjects[objectIndex];
        }
    }
}