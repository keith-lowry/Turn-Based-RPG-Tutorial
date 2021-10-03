using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Abstract class for an Item that affects
/// multiple targets.
/// </summary>
public abstract class MultTargetItem : Item
{
    /// <summary>
    /// Creates a new MultiTarget Item with a default
    /// Quantity of 1.
    /// </summary>
    /// <param name="target">The type of Unit to be Targetted by
    /// this MultiTargetItem.</param>
    public MultTargetItem(string name, TargetType target) : base(name, target, 
        NumberOfTargetsEnum.Multiple) {}

    /// <summary>
    /// Activates the Item's effect on the given array
    /// of targets if the Item's quantity is greater
    /// than 0. Decrements Item quantity when used.
    /// </summary>
    /// <param name="targets">The targets of this Item.</param>
    /// <returns>True if the Item is used, false otherwise.</returns>
    public abstract bool Use(Unit[] targets);
}
