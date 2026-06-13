using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    private CapsuleCollider ColliderPlayer;
    private BoxCollider Hitbox;
    public int direction = 1; 
    

    void Start()
    {
        ColliderPlayer = GetComponent<CapsuleCollider>();
        Hitbox = GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);
    }

  

}