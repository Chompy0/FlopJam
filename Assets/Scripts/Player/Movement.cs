using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public int direction = 1; 
    


    void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);
    }

  

}