public static class InventorySlotUtils
{
    public static void DisplayContents(InventorySlotProps inventorySlotProps, UsableItem usableItem)
    {
        EnableInventorySlot(inventorySlotProps);
        MapInventorySlotToContents(inventorySlotProps, usableItem);
    }
    private static void MapInventorySlotToContents(InventorySlotProps islot, UsableItem uitem)
    {
        switch (uitem.ItemType)
        {
            case ItemType.FragBomb:
                FragBombInventorySlotRenderer.RenderInventorySlot(islot, uitem);
                break;
            default:
                DefaultInventorySlotRenderer.RenderInventorySlot(islot, uitem);
                break;
        }
    }

    public static void DisableInventorySlot(InventorySlotProps islot)
    {
        islot.SpriteRenderer.enabled = false;
        islot.Name.enabled = false;
    }

    private static void EnableInventorySlot(InventorySlotProps islot)
    {
        islot.SpriteRenderer.enabled = true;
        islot.Name.enabled = true;
    }
}
