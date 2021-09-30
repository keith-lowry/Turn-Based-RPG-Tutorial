using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script representing an Inventory of
/// usable Items.
/// </summary>
public class Inventory : MonoBehaviour
{
    private Dictionary<ItemType, Item> itemMap; //current Items in inventory


    public void Awake()
    {
        itemMap = new Dictionary<ItemType, Item>();
    }

    /// <summary>
    /// Gets an Item from the
    /// Inventory if it is in the Inventory.
    /// </summary>
    /// <param name="name">The type of the desired Item.</param>
    /// <returns>The desired Item if it is in the
    /// Inventory. Null otherwise. </returns>
    public Item GetItem(ItemType name)
    {
        if (itemMap.ContainsKey(name))
        {
            return itemMap[name];
        }

        return null;
    }

    /// <summary>
    /// Adds a certain amount of a specific
    /// Item to the Inventory.
    /// </summary>
    /// <param name="name">The type of the Item.</param>
    /// <param name="amount">The amount to be added. Must be greater
    /// than 0.</param>
    /// <returns>True if the Consumable was added, false if Item was not added
    /// because amount was invalid.</returns>
    public bool AddItem(ItemType name, int amount)
    {
        if (amount <= 0)
        {
            return false;
        }
        

        if (itemMap.ContainsKey(name))
        {
            Item i = itemMap[name];
            i.quantity += amount;
            return true;
        }

        Item newItem = ItemDatabase.GetItem(name);
        itemMap.Add(name, newItem);
        newItem.quantity += (amount - 1); //Item has quantity of 1 by default
        return true;
    }

    /// <summary>
    /// Adds one of a specific Item to the Inventory.
    /// </summary>
    /// <param name="name">The type of the Item.</param>
    public void AddItem(ItemType name)
    {
        AddItem(name, 1);
    }

}
