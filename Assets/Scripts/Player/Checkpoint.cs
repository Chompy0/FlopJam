using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Clone clone;


    void Start()
    {
        clone = FindAnyObjectByType<Clone>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Respawn playerRespawn = collision.GetComponent<Respawn>();
            if (playerRespawn != null)
            {
                playerRespawn.SetSpawnPoint(transform);
                clone.playertransforms.Clear();
            }
        }   
    }
}
