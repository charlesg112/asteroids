using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D projectileBody;
    public float speed;

    void Start()
    {
        float rotation = gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));
        Debug.Log($"Rotation : {rotation}, Direction du projectile : {direction}");
        projectileBody.velocity = direction * speed;
    }

    void Update()
    {
        
    }
}
