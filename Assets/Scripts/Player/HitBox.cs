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

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.TryGetComponent(out TilemapCollider2D tilemap) || collision.TryGetComponent(out Clone clone) || collision.TryGetComponent(out Door door))
      movementScript.direction = movementScript.direction * -1;
  }

}
