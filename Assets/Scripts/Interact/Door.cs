using UnityEngine;

public class Door : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;

    public Sprite openSprite;
    public Sprite closedSprite;

    public bool isOpen = false;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResetLevel.Instance.OnPlayerRespawn += CloseDoor;
    }

    public void OpenDoor()
    {
        isOpen = true;
        boxCollider.enabled = false;
        spriteRenderer.sprite = openSprite;
        AudioManager.Instance.PlaySound(AudioType.Door,AudioSourceType.Game);
    }

    public void CloseDoor()
    {
        isOpen = false;
        boxCollider.enabled = true;
        spriteRenderer.sprite = closedSprite;
    }
}