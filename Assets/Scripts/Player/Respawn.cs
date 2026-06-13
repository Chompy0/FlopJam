using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    [SerializeField] private Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            StartCoroutine(RespawnCoroutine(0.5f));
        }    
    }
    IEnumerator RespawnCoroutine(float duration)
    {
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = spawnPoint.position;
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void SetSpawnPoint(Transform newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }

    public void Reset()
    {
        ResetLevel.Instance.OnRespawn();
    }
}
