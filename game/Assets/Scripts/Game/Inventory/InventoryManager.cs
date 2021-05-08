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
            Spawner.InstantiateFragBomb(GameInfo.GetPlayerPosition(), GameInfo.GetAngleBetweenPlayerAndMouse());
        }
        catch (Exception e)
        {
            Debug.Log(e);
            EventBus.Publish(EventType.TriedToUseEmptyItemSlot, this.gameObject, 1);
        }
    } 
}
