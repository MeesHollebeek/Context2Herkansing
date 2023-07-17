using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public string scalableTag = "Scalable";
    public float hoverScale = 1.2f;
    public float scaleSpeed = 5f;

    private Vector3 initialScale;
    private Coroutine scalingCoroutine;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag(scalableTag))
            {
                if (scalingCoroutine != null)
                {
                    StopCoroutine(scalingCoroutine);
                }
                scalingCoroutine = StartCoroutine(ScaleObject(hit.transform, initialScale * hoverScale, scaleSpeed));
            }
            else
            {
                if (scalingCoroutine != null)
                {
                    StopCoroutine(scalingCoroutine);
                }
                scalingCoroutine = StartCoroutine(ScaleObject(hit.transform, initialScale, scaleSpeed));
            }
        }
        else
        {
            if (scalingCoroutine != null)
            {
                StopCoroutine(scalingCoroutine);
            }
            scalingCoroutine = StartCoroutine(ScaleObject(transform, initialScale, scaleSpeed));
        }
    }

    private IEnumerator ScaleObject(Transform target, Vector3 targetScale, float speed)
    {
        Vector3 currentScale = target.localScale;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            target.localScale = Vector3.Lerp(currentScale, targetScale, t);
            yield return null;
        }
    }

    public void StartGame()
    {
        // Add your code to start the game here
    }

    public void QuitGame()
    {
        // Add your code to quit the game here
    }
}