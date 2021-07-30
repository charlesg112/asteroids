using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBarComponent : UIComponent<GameState>
{
    public List<Image> ImageSlots;
    private List<UsableItem> displayedInventory = new List<UsableItem>(GameInfo.INVENTORY_CAPACITY);
    public override bool IsUpdateRequired(GameState state)
    {
        bool isUpdateRequired = state.CurrentInventory != displayedInventory;
        if (isUpdateRequired)
        {
            displayedInventory = state.CurrentInventory;
        }
        Debug.Log($"Inventory State changed ? : {isUpdateRequired}");
        return isUpdateRequired;
    }

    public override void Render(GameState state)
    {
        for (int i = 0; i < displayedInventory.Count; ++i)
        {
            UsableItem currentUsableItem = displayedInventory[i];
            if (currentUsableItem == null) continue;
            try
            {
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
