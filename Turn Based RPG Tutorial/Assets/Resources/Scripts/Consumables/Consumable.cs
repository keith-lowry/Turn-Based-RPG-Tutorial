using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;


public abstract class Consumable
{
    public int quantity;


    /// <summary>
    /// Activates the Consumable's effect. Decrements
    /// the consumable's quantity.
    /// </summary>
    /// <param name="playerUnit">The player.</param>
    /// <param name="enemyUnit">The enemy.</param>
    /// <returns>True if the item was used, false
    /// otherwise.</returns>
    public abstract bool Use(Unit playerUnit, Unit enemyUnit);

    /// <summary>
    /// Gets 
    /// </summary>
    /// <returns>The String dialogue to be displayed
    /// when the Consumable is used.</returns>
    public abstract String getUseDialogue(Unit playerUnit, Unit enemyUnit);


}
