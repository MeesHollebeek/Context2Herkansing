using UnityEngine;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{
    public GameObject infoPanel;

    // This function will be called when the mouse pointer enters the UI element.
    public void OnPointerEnter()
    {
        Debug.Log("Mouse entered the button.");
        infoPanel.SetActive(true);
    }

    // This function will be called when the mouse pointer exits the UI element.
    public void OnPointerExit()
    {
        Debug.Log("Mouse exited the button.");
        infoPanel.SetActive(false);
    }
}