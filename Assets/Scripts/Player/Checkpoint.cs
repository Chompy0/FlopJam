using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Clone clone;

    [SerializeField] Camera cam;

    Vector3 camPosition;


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
                cam.transform.position = Vector3.Lerp(cam.transform.position,camPosition,1);
                clone.playertransforms.Clear();
            }
        }   
    }
}
