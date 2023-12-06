using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 5f;
    public float verticalRotationLimit = 90f;

    private float verticalRotation = 0f;

    private void Update()
    {
        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the character horizontally
        transform.parent.Rotate(0f, mouseX, 0f);

        // Rotate the camera vertically
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
