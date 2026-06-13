using UnityEngine;

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
        movementScript.direction = movementScript.direction * -1;
    }
}
