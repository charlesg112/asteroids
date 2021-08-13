using System.Collections.Generic;

public class InventoryBarComponent : UIComponent<GameState>
{
    public List<InventorySlotProps> InventorySlots;
    private List<UsableItem> displayedInventory = new List<UsableItem>(GameInfo.INVENTORY_CAPACITY);
    public override bool IsUpdateRequired(GameState state)
    {
        displayedInventory = state.CurrentInventory;
        return true;
    }

    public override void Render(GameState state)
    {
        for (int i = 0; i < InventorySlots.Count; ++i)
        {
            try
            {
                InventorySlotUtils.DisplayContents(InventorySlots[i], displayedInventory[i]);
            }
            catch
            {
                InventorySlotUtils.DisableInventorySlot(InventorySlots[i]);
            }
        }
    }
}
