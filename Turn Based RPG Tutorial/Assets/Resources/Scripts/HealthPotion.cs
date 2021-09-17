using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Consumable
{
    public int quantity;

    public static readonly int baseHeal = 50;

    public override void Use(Unit playerUnit, Unit enemyUnit)
    {
        if (quantity > 0)
        {
            playerUnit.Heal(baseHeal);
            quantity--;
        }
    }
}
