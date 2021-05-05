using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<GameObject> items = new List<GameObject>();
    public ItemSpawner Spawner;
    public void AddItem(GameObject item)
    {
        items.Add(item);
    }

    public void UseItem(int index)
    {
        try {
            Spawner.InstantiateFragBomb(new Vector2(0, 0), 20);
        }
        catch (Exception e)
        {
            Debug.Log(e);
            EventBus.Publish(EventType.TriedToUseEmptyItemSlot, this.gameObject, 1);
        }
    } 
}
