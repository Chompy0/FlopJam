using UnityEngine;

public class Button : MonoBehaviour
{
    public bool isPressed = false;
    public ButtonType buttonType;
    [SerializeField] private Door door;
    [SerializeField] private Button linkedButton;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.TryGetComponent(out Clone clone))
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
        if (collision.CompareTag("Player") || collision.TryGetComponent(out Clone clone))
        {
            if (buttonType == ButtonType.ToggleButtonDoor)
            {
                isPressed = false;
                door.CloseDoor();
            }
            if (buttonType == ButtonType.LinkedButtonDoor)
            {

                isPressed = false;

            }
            if (buttonType == ButtonType.PressButtonDoor)
            {
                isPressed = false;
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