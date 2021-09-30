using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

/// <summary>
/// Consumable representing a simple
/// health potion.
/// 
/// Not a MonoBehavior.
/// </summary>
public class HealthPotion : Item
{

    public static readonly int baseHeal = 50;

    public ItemType Type
    {
        get
        {
            return HealthPotion.type;
        }
    }

    private static readonly ItemType type = ItemType.HealthPotion;

    /// <summary>
    /// Creates a new HealthPotion with
    /// a default quantity of 1.
    /// </summary>
    public HealthPotion() : base() {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="playerUnit"></param>
    /// <param name="enemyUnit"></param>
    /// <returns>Returns true if the item was used,
    /// false if there was no item left to use.</returns>
    public override bool Use(Unit playerUnit, Unit enemyUnit)
    {
        if (quantity > 0)
        {
            playerUnit.Heal(baseHeal);
            quantity--;
            return true;
        }

        return false;
    }


    public override string GetUseDialogue(Unit playerUnit, Unit enemyUnit)
    {
        return playerUnit.unitName + " healed " + 50 + " health.";
    }
}
