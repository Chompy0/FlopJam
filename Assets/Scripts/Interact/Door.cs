using UnityEngine;

public class Door : MonoBehaviour
{
    BoxCollider2D boxCollider;
    public bool isOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        ResetLevel.Instance.OnPlayerRespawn += CloseDoor;
    }
    public void OpenDoor()
    {
        isOpen = true;
        boxCollider.enabled = false;

    }
    public void CloseDoor()
    {
        isOpen = false;
        boxCollider.enabled = true;
    }
}
