using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;          // Speed of the player
    public float jumpForce = 5f;         // Force applied for jumping
    public float gravity = -9.81f;       // Gravity value
    public Transform cameraTransform;    // Reference to the camera
    public CharacterController controller; // CharacterController component for movement

    private Vector3 velocity;            // Player's current velocity
    private bool isGrounded;             // Is the player on the ground?

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset downward velocity when on the ground
        }

        // Get input from the keyboard (WASD keys)
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        // Calculate movement direction based on camera orientation
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            // Calculate the direction relative to the camera
            Vector3 moveDirection = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0) * direction;

            // Move the player
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Apply jump force
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); // Apply vertical movement
    }
}
