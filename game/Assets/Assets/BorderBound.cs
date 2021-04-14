using UnityEngine;

public abstract class BorderBound : MonoBehaviour
{
    public LayerMask border;
    public Rigidbody2D body;
    public Collider2D objCollider;
    private Plane[] planes;

    protected abstract void BorderCollisionEvent();

    bool IsCollidingWithTopOrBottomOfScreen()
    {
        return objCollider.IsTouchingLayers(border);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        Debug.Log(collision.gameObject.layer);
    }

    void Update()
    {
    }
}
