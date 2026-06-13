using UnityEngine;

public class Button : MonoBehaviour
{
    public bool isPressed = false;
    public ButtonType buttonType;
    [SerializeField] private Door door;
    [SerializeField] private Button linkedButton; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (buttonType == ButtonType.PressButtonDoor && !isPressed)
            {
                isPressed = true;
                door.OpenDoor();
            }
            if (buttonType == ButtonType.ToggleButtonDoor && !isPressed)
            {
                isPressed = true;
                door.OpenDoor();
            }
            if (buttonType == ButtonType.LinkedButtonDoor)
            {
                isPressed = true;
                if (linkedButton != null && linkedButton.isPressed)
                    door.OpenDoor();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (buttonType == ButtonType.ToggleButtonDoor)
            {
                isPressed = false;
                door.CloseDoor();
            }
            if (buttonType == ButtonType.LinkedButtonDoor)
            {
                if(!door.isOpen)
                {
                    isPressed = false;
                }
            }
        }
    }

    public enum ButtonType
    {
        PressButtonDoor,
        ToggleButtonDoor,
        LinkedButtonDoor
    }
}