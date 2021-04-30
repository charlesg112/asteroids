using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items;
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void UseItem(int index)
    {
        try { 
            items[index].Use();
            items.Remove(items[index]);
        }
        catch
        {
            EventBus.Publish(EventType.TriedToUseEmptyItemSlot, this.gameObject, 1);
        }
    } 
}
