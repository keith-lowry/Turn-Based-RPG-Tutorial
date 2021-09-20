using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Consumable representing a simple
/// health potion.
/// 
/// Not a MonoBehavior.
/// </summary>
public class HealthPotion : Consumable
{

    public static readonly int baseHeal = 50;

    public ConsumableType Type
    {
        get
        {
            return type;
        }
    }

    private readonly ConsumableType type = ConsumableType.HealthPotion;

    public HealthPotion()
    {
        quantity = 0;
    }

    public HealthPotion(int i)
    {
        quantity = i;
    }

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


    public override string getUseDialogue(Unit playerUnit, Unit enemyUnit)
    {
        return playerUnit.unitName + " healed " + 50 + " health.";
    }
}
