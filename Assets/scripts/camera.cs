using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;  // The object the camera will follow
    public Vector3 offset;    // Offset position relative to the target
    public float smoothSpeed = 0.125f;  // Smoothing speed for smooth transitions
    public float mouseSensitivity = 100f; // Sensitivity for mouse movement

    private float pitch = 0f; // Vertical rotation (up/down)
    private float yaw = 0f;   // Horizontal rotation (left/right)

    void Start()
    {
        // Make the cursor invisible and lock it to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return; // Ensure there's a target to follow

        // Smoothly follow the target
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust pitch and yaw based on mouse input
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // Limit vertical rotation

        // Rotate the camera to follow the cursor
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
