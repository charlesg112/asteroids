using UnityEngine;

public class SpritesUtils : MonoBehaviour
{
    public Sprite FragBomb;
    public Sprite Unknown;
    private static SpritesUtils instance;
    public void Start()
    {
        instance = this;
    }
    public static SpritesUtils GetInstance()
    {
        return instance;
    }
    public Sprite GetSpriteFromItemType(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.FragBomb:
                return FragBomb;
            default:
                return Unknown;
        }
    }
}
