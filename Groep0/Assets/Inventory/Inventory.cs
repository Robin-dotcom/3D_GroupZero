using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<String, InventoryItem> inventory;
    
    void Start()
    {
        this.inventory = new Dictionary<String, InventoryItem>();
    }

    public void AddItem(InventoryItem item)
    {
        this.inventory[item.DisplayName] = item;
    }

    public void RemoveItem(InventoryItem item)
    {
        this.inventory.Remove(item.DisplayName);
    }
}
