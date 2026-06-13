using UnityEngine;

public class Button : MonoBehaviour
{
    public bool isPressed = false;

    ButtonType buttonType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      public enum ButtonType
    {
        Press,
        Toggle

    }
}
