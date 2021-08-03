using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySupervisor
{
    private static InventorySupervisor instance;
    private List<UsableItem> items = new List<UsableItem>();
    private int itemsInInventory = 0;
    private int inventoryCapacity = GameInfo.INVENTORY_CAPACITY;

    public static InventorySupervisor GetInstance()
    {
        if (instance == null) instance = new InventorySupervisor();
        return instance;
    }

    public void AddItem(UsableItem item)
    {
        if (itemsInInventory < inventoryCapacity)
        {
            items.Add(item);
            itemsInInventory++;
            Debug.Log(this);
        }
    }
    public void UseItem(int index)
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
    public List<UsableItem> GetCurrentInventory()
    {
        return items;
    }

    public override string ToString()
    {
        string output = $"Inventory Contents (size = {items.Count})";
        items.ForEach(i => output += $"\n     - {i.ItemType} [InstanceID : {i.GetInstanceID()}]");
        return output;
    }
}
