using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform buttonRectTransform;
    private Vector3 originalScale;

    private void Start()
    {
        // Get the button's RectTransform component and store its original scale.
        buttonRectTransform = GetComponent<RectTransform>();
        originalScale = buttonRectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Increase the button's scale when the mouse enters.
        buttonRectTransform.localScale = originalScale * 1.1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Restore the button's original scale when the mouse exits.
        buttonRectTransform.localScale = originalScale;
    }
}