using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;


public enum ConsumableName
{
    HealthPotion,
}


public abstract class Consumable
{
    public int quantity;

    /**
     * Activates the Consumable's effect. Decrements
     * the consumable's quantity.
     */
    public abstract void Use(Unit playerUnit, Unit enemyUnit);


}
