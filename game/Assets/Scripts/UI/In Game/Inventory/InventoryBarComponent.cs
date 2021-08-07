using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBarComponent : UIComponent<GameState>
{
    public List<Image> ImageSlots;
    private List<UsableItem> displayedInventory = new List<UsableItem>(GameInfo.INVENTORY_CAPACITY);
    public override bool IsUpdateRequired(GameState state)
    {
        displayedInventory = state.CurrentInventory;
        return true;
    }

    public override void Render(GameState state)
    {
        for (int i = 0; i < ImageSlots.Count; ++i)
        {
            try
            {
                UsableItem currentUsableItem = displayedInventory[i];
                if (currentUsableItem == null) ImageSlots[i].enabled = false;
                ImageSlots[i].enabled = true;
                ImageSlots[i].sprite = SpritesUtils.GetInstance().GetSpriteFromItemType(currentUsableItem.ItemType);
            }
            catch
            {
                ImageSlots[i].enabled = false;
            }
        }
    }
}
