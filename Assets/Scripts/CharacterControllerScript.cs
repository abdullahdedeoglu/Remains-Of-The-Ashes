using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float movementSpeed = 10f; // The movement speed of the character
    public float mouseSensitivity = 5f; // The mouse sensitivity for camera rotation
    public float gravity = -9.81f; // The gravitational force
    public float jumpHeight = 1.25f; // The height of the jump

    private CharacterController characterController;
    private Transform cameraTransform;
    private float verticalRotation = 0f;
    private Vector3 playerVelocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Get the player's input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction based on the input
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection = transform.TransformDirection(movementDirection);
        movementDirection *= movementSpeed;

        // Apply gravity to the player
        playerVelocity.y += gravity * Time.deltaTime;
        movementDirection.y = playerVelocity.y;

        // Apply the movement to the character controller
        characterController.Move(movementDirection * Time.deltaTime);

        // Check if the character is grounded
        if (characterController.isGrounded)
        {
            // Reset the vertical velocity if grounded
            playerVelocity.y = 0f;

            // Check for jump input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Apply jump force
                playerVelocity.y = Mathf.Sqrt(-2f * gravity * jumpHeight);
            }
        }

        // Get the player's input for mouse rotation
        float mouseHorizontalInput = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseVerticalInput = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the character horizontally
        transform.Rotate(0f, mouseHorizontalInput, 0f);

        // Rotate the camera vertically
        verticalRotation -= mouseVerticalInput;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Rotate the character vertically
        float characterRotation = cameraTransform.localEulerAngles.x;
        characterRotation += mouseVerticalInput;
        characterRotation = Mathf.Clamp(characterRotation, -90f, 90f);
        cameraTransform.localEulerAngles = new Vector3(characterRotation, 0f, 0f);
    }
}
