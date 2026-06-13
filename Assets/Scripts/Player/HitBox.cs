using UnityEngine;
using UnityEngine.Tilemaps;

public class HitBox : MonoBehaviour
{
  Movement movementScript;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    movementScript = GetComponentInParent<Movement>();
  }

  // Update is called once per frame
  void Update()
  {

  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.TryGetComponent(out TilemapCollider2D tilemap) || collision.TryGetComponent(out Clone component))
      movementScript.direction = movementScript.direction * -1;
  }
}
