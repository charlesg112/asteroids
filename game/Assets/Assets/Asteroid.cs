using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Vector2 initialVelocity;
    public Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
    }

    void Update()
    {
        
    }
}
