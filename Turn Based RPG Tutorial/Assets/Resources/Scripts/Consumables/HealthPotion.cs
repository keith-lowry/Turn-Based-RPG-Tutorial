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

    public HealthPotion()
    {
        quantity = 0;
    }

    public HealthPotion(int i)
    {
        quantity = i;
    }

    public override void Use(Unit playerUnit, Unit enemyUnit)
    {
        if (quantity > 0)
        {
            playerUnit.Heal(baseHeal);
            quantity--;
        }
    }
}
