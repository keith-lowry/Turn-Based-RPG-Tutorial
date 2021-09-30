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
    protected int quantity;

    /// <summary>
    /// Creates a new Item with a default quantity
    /// of 1.
    /// </summary>
    public Item()
    {
        quantity = 1;
    }

    /// <summary>
    /// Activates the Item's effect if it's quantity is
    /// greater than 0. Decrements
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
    public abstract String GetUseDialogue(Unit playerUnit, Unit enemyUnit);


    /// <summary>
    /// Gets the String dialogue to be displayed
    /// when the Item is not used.
    /// </summary>
    /// <returns>The Item's non-use dialogue.</returns>
    public virtual String GetNonUseDialogue()
    {
        if (quantity <= 0)
        {
            return "You're out of that";
        }

        return "You can't do that right now";
    }

    /// <summary>
    /// Increases the Item's quantity
    /// by a certain amount.
    /// </summary>
    /// <param name="q">The amount to add
    /// to the Item's quantity.</param>
    public void AddQuantity(int q)
    {
        quantity += q;
    }


}
