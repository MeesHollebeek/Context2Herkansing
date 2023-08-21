using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickSpawn : MonoBehaviour
{
    private GameObject selectedObject; // The currently selected object
    public LayerMask clickableLayer;   // Assign the specific layer in the Inspector
    public GameObject particleSystemPrefab; // Assign the Particle System prefab in the Inspector
    public MoneyCounter moneyManager; // Reference to the MoneyManager script
    public float spawnCooldown = 2.0f;  // The cooldown time in seconds
    private float lastSpawnTime;        // The time when the last object was spawned

    // List of spawnable objects to assign in the Inspector
    public List<GameObject> spawnableObjects = new List<GameObject>();
    public float fixedXPosition = -0.0f; // The fixed X position

    void Update()
    {
        // Check if the cooldown time has passed
        if (Time.time - lastSpawnTime >= spawnCooldown)
        {
            if (Input.GetMouseButtonDown(0) && selectedObject != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer.value) && hit.collider.gameObject == gameObject)
                {
                    int cost = CalculateCostOfSelectedObject();

                    if (moneyManager.Money >= cost)
                    {
                        moneyManager.SpendMoney(cost);

                        // Set the spawn position
                        Vector3 spawnPosition = new Vector3(fixedXPosition, hit.point.y, hit.point.z);

                        // Instantiate the selected object at the spawn position
                        GameObject spawnedObject = Instantiate(selectedObject, spawnPosition, Quaternion.identity);

                        // Instantiate the particle system at the same position
                        Instantiate(particleSystemPrefab, spawnPosition, Quaternion.identity);

                        lastSpawnTime = Time.time;
                    }
                    else
                    {
                        Debug.Log("Not enough money!");
                    }
                }
            }
        }
    }
    int CalculateCostOfSelectedObject()
    {
        // Replace "BuildingCost" with the actual script attached to your selected objects
        // that holds the cost information
        return selectedObject.GetComponent<ObjectCost>().cost;
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