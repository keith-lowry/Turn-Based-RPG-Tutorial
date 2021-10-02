using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

/// <summary>
/// Singleton Item representing a simple
/// health potion.
/// 
/// Not a MonoBehavior.
/// </summary>
public class HealthPotion : Item
{
    public static readonly int baseHeal = 15;

    private bool unitHealBlocked;
    private int deltaHP;

    //Singleton Instance
    private static HealthPotion _instance;

    /// <summary>
    /// Gets the instance of the
    /// HealthPotion.
    /// </summary>
    public static HealthPotion Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new HealthPotion();
            }

            return _instance;
        }
    }

    /// <summary>
    /// Creates a new HealthPotion with
    /// a default quantity of 1.
    /// </summary>
    private HealthPotion() : base() {}

    public override bool Use(Unit playerUnit, Unit enemyUnit)
    {
        if (quantity <= 0)
        {
            return false;
        }


        int hpBefore = playerUnit.CurrentHP;

        unitHealBlocked = !playerUnit.Heal(baseHeal);

        int hpAfter = playerUnit.CurrentHP;


        if (unitHealBlocked)
        { 
            return false;
        }

        deltaHP = hpAfter - hpBefore;
        quantity--;
        return true;
    }


    public override String GetNonUseDialogue()
    {
        if (quantity <= 0)
        {
            return "You're out of that";
        }

        if (unitHealBlocked)
        {
            return "This unit doesn't need this at the moment";
        }

        return "You can't do that right now";
    }

    public override string GetUseDialogue(Unit playerUnit, Unit enemyUnit)
    {
        return playerUnit.unitName + " healed " + deltaHP + " health";
    }
}
