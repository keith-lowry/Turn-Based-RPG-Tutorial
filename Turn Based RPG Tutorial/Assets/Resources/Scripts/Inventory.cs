using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<ConsumableType, Consumable> itemMap; //party's current
                                                            //items


    public void Awake()
    {
        itemMap = new Dictionary<ConsumableType, Consumable>();

        //Add all possible items
        SetUpMap();
    }

    /// <summary>
    /// Gets a consumable from the party's
    /// inventory.
    /// </summary>
    /// <param name="name">The name of the consumable.</param>
    /// <returns>The associated consumable if it is in the
    /// inventory. Null otherwise. </returns>
    public Consumable GetItem(ConsumableType name)
    {
        if (itemMap.ContainsKey(name))
        {
            return itemMap[name];
        }

        return null;
    }

    /// <summary>
    /// Adds a certain amount of a specific
    /// consumable to the party's inventory.
    /// </summary>
    /// <param name="name">The name of the consumable. Must already
    /// be in the item Map.</param>
    /// <param name="amount">The amount to be added, must be greater
    /// than 0.</param>
    /// <returns>True if the consumable was added, false otherwise.</returns>
    public bool AddItem(ConsumableType name, int amount)
    {
        if (itemMap.ContainsKey(name) && amount > 0)
        {
            Consumable c = itemMap[name];
            c.quantity += amount;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Adds all possible items to the
    /// itemMap.
    /// </summary>
    private void SetUpMap()
    {
        HealthPotion hpPot = new HealthPotion();
        itemMap.Add(hpPot.Type, hpPot);
    }
}
