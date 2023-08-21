using UnityEngine;
using UnityEngine.UI;

public class HouseCounter : MonoBehaviour
{
    public Text counterText; // Reference to the Text UI element
    private int houseCount = 0; // Counter for houses spawned
    public Text scoreText;
    private int ScoreCount = 0;
    private void Start()
    {
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        counterText.text = "Population: " + houseCount;
        scoreText.text = "Score: " + houseCount;
    }

    public void IncrementHouseCount()
    {
        houseCount++;
        UpdateCounterText();
    }
}