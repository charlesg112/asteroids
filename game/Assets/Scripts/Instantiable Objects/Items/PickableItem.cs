using System.Collections;
using UnityEngine;

public abstract class PickableItem : MonoBehaviour
{
    public int DespawnTimer;
    public SpriteRenderer SpriteRenderer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.layer)
        {
         case GameInfo.LAYER_OF_PLAYER:
                PlayerCollisionEvent(collision); break;
        }
    }
    
    private void Start()
    {
        StartCoroutine(DestroyAfterTimeout());
    }

    private IEnumerator DestroyAfterTimeout()
    {
        yield return new WaitForSeconds(DespawnTimer - 0.5f);
        for (int i = 0; i < 100; ++i)
        {
            if (this.gameObject == null) yield break;
            yield return new WaitForSeconds(0.5f / 255.0f);
            Color color = SpriteRenderer.color;
            color.a -= 0.01f;
            SpriteRenderer.color = color;
        }
        if (this.gameObject) Destroy(this.gameObject);
    }

    internal abstract void PlayerCollisionEvent(Collider2D collider);
}
