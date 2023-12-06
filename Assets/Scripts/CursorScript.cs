using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Texture2D cursorTexture; // The cursor texture
    public Vector2 cursorHotspot; // The cursor hotspot position

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Keep the cursor fixed at the center of the screen
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(screenCenter);
        transform.position = cursorPosition;
    }
}
