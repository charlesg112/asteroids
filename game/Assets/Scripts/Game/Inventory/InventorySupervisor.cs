using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySupervisor : MonoBehaviour
{
    private static List<GameObject> items = new List<GameObject>();
    public static void AddItem(GameObject item)
    {
        items.Add(item);
        Debug.Log("InventorySupervisor : Picked up item");
    }

    public static void UseItem(int index)
    {
        try {
            UsableItem usableItem = items[index].GetComponent(typeof(UsableItem)) as UsableItem;
            usableItem.Use();
        }
        catch (Exception e)
        {
            Debug.Log(e);
            //EventBus.Publish(EventType.TriedToUseEmptyItemSlot, this.gameObject, 1);
        }
    } 
}
