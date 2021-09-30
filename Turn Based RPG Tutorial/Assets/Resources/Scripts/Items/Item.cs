using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;


/// <summary>
/// Abstract class representing an Item
/// that can be used in battle.
/// </summary>
public abstract class Item
{
    public int quantity;

    /// <summary>
    /// Creates a new Item with a default quantity
    /// of 1.
    /// </summary>
    public Item()
    {
        quantity = 1;
    }

    /// <summary>
    /// Activates the Item's effect. Decrements
    /// the consumable's quantity.
    /// </summary>
    /// <param name="playerUnit">The player.</param>
    /// <param name="enemyUnit">The enemy.</param>
    /// <returns>True if the Item was used, false
    /// otherwise.</returns>
    public abstract bool Use(Unit playerUnit, Unit enemyUnit);

    /// <summary>
    /// Gets the String dialogue to be displayed
    /// when the Item is used.
    /// </summary>
    /// <returns>The Item's use dialogue.</returns>
    public abstract String getUseDialogue(Unit playerUnit, Unit enemyUnit);


}
