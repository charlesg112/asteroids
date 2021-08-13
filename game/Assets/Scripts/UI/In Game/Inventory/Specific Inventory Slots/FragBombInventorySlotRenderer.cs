public static class FragBombInventorySlotRenderer
{
    public static void RenderInventorySlot(InventorySlotProps inventorySlotProps, UsableItem usableItem)
    {
        DefaultInventorySlotRenderer.RenderInventorySlot(inventorySlotProps, usableItem);
        inventorySlotProps.Name.text = "FRAG";
    }
}
