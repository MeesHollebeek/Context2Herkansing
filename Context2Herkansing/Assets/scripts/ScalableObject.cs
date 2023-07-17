using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScalableObject : MonoBehaviour
{
    public float hoverScale = 1.2f;
    public float scaleSpeed = 5f;
    public float hoverRotationAmount = 15f;
    public string gameSceneName = "GameScene";
    public bool isStartButton = true;

    private Vector3 initialScale;
    private Quaternion initialRotation;
    private Coroutine scalingCoroutine;

    private void Start()
    {
        initialScale = transform.localScale;
        initialRotation = transform.rotation;
    }

    private void OnMouseEnter()
    {
        if (scalingCoroutine != null)
        {
            StopCoroutine(scalingCoroutine);
        }
        scalingCoroutine = StartCoroutine(ScaleAndRotateObject(initialScale * hoverScale, Quaternion.Euler(0f, 0f, hoverRotationAmount)));
    }

    private void OnMouseExit()
    {
        if (scalingCoroutine != null)
        {
            StopCoroutine(scalingCoroutine);
        }
        scalingCoroutine = StartCoroutine(ScaleAndRotateObject(initialScale, initialRotation));
    }

    private void OnMouseDown()
    {
        if (isStartButton)
        {
            SceneManager.LoadScene(gameSceneName);
        }
        else
        {
            Application.Quit();
        }
    }

    private IEnumerator ScaleAndRotateObject(Vector3 targetScale, Quaternion targetRotation)
    {
        Vector3 currentScale = transform.localScale;
        Quaternion currentRotation = transform.rotation;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(currentScale, targetScale, t);
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, t);
            yield return null;
        }
    }

    public void SetAsStartButton()
    {
        isStartButton = true;
    }

    public void SetAsQuitButton()
    {
        isStartButton = false;
    }
}