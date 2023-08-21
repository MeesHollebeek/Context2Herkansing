using UnityEngine;
using System.Collections.Generic;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;
    public List<GameObject> unpauseObjects;
    public LayerMask pauseLayer;
    public GameObject pauseMenu;

    // Other variables and methods

    void Update()
{
    // Check if the spacebar is pressed
    if (Input.GetKeyDown(KeyCode.Space))
    {
        TogglePause();
    }
}

void TogglePause()
{
    isPaused = !isPaused;

    // Pause or unpause the game
    if (isPaused)
    {
        Time.timeScale = 0; // Set the time scale to 0 to pause the game
            pauseMenu.SetActive(true);

            // Pause objects with the specified layer
            foreach (var obj in unpauseObjects)
        {
            if (obj.layer != pauseLayer)
            {
                obj.GetComponent<Rigidbody>().Sleep(); // You can adjust this as needed for your objects
                }
        }
    }
    else
    {
        Time.timeScale = 1; // Set the time scale to 1 to resume the game
            pauseMenu.SetActive(false);
            // Unpause objects with the specified layer
            foreach (var obj in unpauseObjects)
        {
            if (obj.layer != pauseLayer)
            {
                obj.GetComponent<Rigidbody>().WakeUp(); // You can adjust this as needed for your objects
                 
                }
        }
    }
}
}