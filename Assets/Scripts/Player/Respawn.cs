using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class Respawn : MonoBehaviour
{

    [SerializeField] private Transform spawnPoint;

    private MainController controller;

    void Awake()
    {
        controller = new MainController();
    }

    void OnEnable()
    {
        controller.Enable();
        controller.Player.Respawn.performed += OnRespawn;
    }

    void OnDisable()
    {
        controller.Player.Respawn.performed -= OnRespawn;
        controller.Disable();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            StartCoroutine(RespawnCoroutine(1f));

        }
    }
    IEnumerator RespawnCoroutine(float duration)
    {
        transform.localScale = new Vector3(0, 0, 0);
        Reset();
        yield return new WaitForSeconds(duration);
        transform.position = spawnPoint.position;
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnRespawn(InputAction.CallbackContext context)
    {
        StartCoroutine(RespawnCoroutine(1f));

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
