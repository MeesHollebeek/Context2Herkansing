using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickSpawn : MonoBehaviour
{
    private GameObject selectedObject; // The currently selected object
    public LayerMask clickableLayer;   // Assign the specific layer in the Inspector
    public GameObject particleSystemPrefab; // Assign the Particle System prefab in the Inspector
    public MoneyCounter moneyManager; // Reference to the MoneyManager script

    // List of spawnable objects to assign in the Inspector
    public List<GameObject> spawnableObjects = new List<GameObject>();

    void Update()
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

                    // Instantiate the selected object at the clicked position
                    GameObject spawnedObject = Instantiate(selectedObject, hit.point, Quaternion.identity);

                    // Instantiate the particle system at the same position
                    Instantiate(particleSystemPrefab, hit.point, Quaternion.identity);
                }
                else
                {
                    Debug.Log("Not enough money!");
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