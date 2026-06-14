using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Clone clone;
    SpriteRenderer spriteRenderer;
    public Sprite checkpointSprite;


    [SerializeField] Camera cam;

    public Vector3 camPosition;

    public float camSize;


    void Start()
    {
        clone = FindAnyObjectByType<Clone>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Respawn playerRespawn = collision.GetComponent<Respawn>();
            AudioManager.Instance.PlaySound(AudioType.Checkpoint,AudioSourceType.Game);
            if (playerRespawn != null)
            {
                playerRespawn.SetSpawnPoint(transform);
                cam.transform.position = Vector3.Lerp(cam.transform.position,camPosition,1);
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camSize,1);
                
                spriteRenderer.sprite = checkpointSprite;
                clone.playertransforms.Clear();
            }
        }   
    }
}
