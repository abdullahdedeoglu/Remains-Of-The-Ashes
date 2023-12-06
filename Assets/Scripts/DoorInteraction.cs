using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;

    private bool isDoorOpen = false;

    private void Start()
    {
        // Make sure the door is initially closed
        doorAnimator.SetBool("IsOpen", false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            print("deneme");
            if (isDoorOpen)
            {
                OpenDoor();
                
            }
            else
            {
                CloseDoor();
            }
        }
    }

    private void OpenDoor()
    {
        doorAnimator.SetBool("IsOpen", true);
        isDoorOpen = true;
    }

    private void CloseDoor()
    {
        doorAnimator.SetBool("IsOpen", false);
        isDoorOpen = false;
    }
}
