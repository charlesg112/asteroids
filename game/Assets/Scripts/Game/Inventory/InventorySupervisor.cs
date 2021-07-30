using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySupervisor
{
    private static List<UsableItem> items = new List<UsableItem>();
    private static int itemsInInventory = 0;
    private static int inventoryCapacity = GameInfo.INVENTORY_CAPACITY;

    public static void AddItem(UsableItem item)
    {
        if (itemsInInventory < inventoryCapacity)
        {
            items.Add(item);
            itemsInInventory++;
            Debug.Log($"COUNT DE L'INVENTAIRE : {items.Count}");
        }
    }
    public static void UseItem(int index)
    {
        try {
            UsableItem usableItem = items[index];
            usableItem.Use();
        }
        catch (Exception e)
        {
            Debug.Log(e);
            EventBus.Publish(EventType.TriedToUseEmptyItemSlot, null, 0);
        }
    }
    public static List<UsableItem> GetCurrentInventory()
    {
        return items;
    }
}
