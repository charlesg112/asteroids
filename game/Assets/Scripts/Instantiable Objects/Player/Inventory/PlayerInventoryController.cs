using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    public InventoryManager inventoryManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            TryUseSlotOne();
        }
    }

    private void TryUseSlotOne() {
        Debug.Log("Tried to use slot one");
        inventoryManager.UseItem(0);
    }
}
