using UnityEngine;

public static class DefaultInventorySlotRenderer
{
    public static void RenderInventorySlot(InventorySlotProps inventorySlotProps, UsableItem usableItem)
    {
        inventorySlotProps.SpriteRenderer.sprite = SpritesUtils.GetInstance().GetSpriteFromItemType(usableItem.ItemType);
    }
}
