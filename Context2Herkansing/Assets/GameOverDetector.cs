using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    public Transform endLine; // The invisible line's end point
    public GameObject gameOverPanel; // The UI panel displaying "Game Over"
    public Canvas originalCanvas; // Reference to the original UI canvas
    public List<GameObject> objectsToHide; // List of objects to hide when triggered

    private bool isGameOver = false;

    private void Start()
    {
        originalCanvas.enabled = true; // Enable the original UI canvas at the start
    }

    private void Update()
    {
        if (!isGameOver && Vector3.Distance(transform.position, endLine.position) < 3.0f)
        {
            ShowGameOver();
        }
    }

    private void ShowGameOver()
    {
        isGameOver = true;

        // Hide objects in the list
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }

        originalCanvas.enabled = false; // Hide the original UI canvas
        gameOverPanel.SetActive(true); // Show the "Game Over" UI panel
    }
}