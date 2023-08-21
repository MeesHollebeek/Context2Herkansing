
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target; // The object to orbit around
    public float rotationSpeed = 5f; // Speed of rotation
    public float minYAngle = -60f; // Minimum vertical angle
    public float maxYAngle = 60f; // Maximum vertical angle
    public float minXAngle = 60f; // Minimum horizontal angle
    public float maxXAngle = 120f; // Maximum horizontal angle
    public float minDistance = 2f; // Minimum distance from the target
    public float maxDistance = 20f; // Maximum distance from the target
    public float scrollSpeed = 2f; // Speed of zoom
    public float lagSpeed = 10f; // Speed of camera lag

    private float mouseX; // Mouse X position
    private float mouseY; // Mouse Y position
    private float currentDistance; // Current distance from the target

    private Vector3 lastMousePosition; // Last recorded mouse position
    private Vector3 deltaMousePosition; // Change in mouse position

    private Vector3 targetRotation; // Target rotation for the camera

    private bool isRotating = false; // Flag to check if camera rotation is enabled

    private void Start()
    {
        // Set the initial rotation of the camera to the desired starting position
        targetRotation = new Vector3(0f, 90f, 0f);

        // Set the initial position of the camera
        Vector3 desiredPosition = target.position - Quaternion.Euler(targetRotation) * Vector3.forward * maxDistance;
        transform.position = desiredPosition;

        currentDistance = maxDistance;

        lastMousePosition = Input.mousePosition;
        isRotating = false; // Disable rotation initially
    }

    private void Update()
    {
        // Check for right mouse button press
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }

        // Check for right mouse button release
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        // Perform camera rotation only if rotation is enabled
        if (isRotating)
        {
            // Get the mouse X and Y positions
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

            // Calculate the change in mouse position
            deltaMousePosition = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;

            // Calculate the target rotation for the camera
            targetRotation.x -= deltaMousePosition.y;
            targetRotation.y += deltaMousePosition.x;
            targetRotation.x = Mathf.Clamp(targetRotation.x, minYAngle, maxYAngle);
            targetRotation.y = Mathf.Clamp(targetRotation.y, minXAngle, maxXAngle);
        }

        // Zoom in and out with the scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        currentDistance -= scroll * scrollSpeed;
        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

        // Smoothly interpolate towards the target rotation
        Quaternion rotation = Quaternion.Euler(targetRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * lagSpeed);

        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position - transform.forward * currentDistance;

        // Update the camera's position
        transform.position = desiredPosition;
    }
}