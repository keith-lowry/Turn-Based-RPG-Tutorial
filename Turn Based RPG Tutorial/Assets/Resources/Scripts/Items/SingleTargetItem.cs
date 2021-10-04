using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// Abstract class for an Item that
/// affects only a singular target.
/// </summary>
public abstract class SingleTargetItem : Item
{
    /// <summary>
    /// Creates a new SingleTargetItem with a default Quantity
    /// of 1 and the given Target Type.
    /// </summary>
    /// <param name="target">The type of Target for this Item.</param>
    public SingleTargetItem(string name, TargetType target) : base(name, target,
        NumberOfTargetsEnum.Single) {}

    /// <summary>
    /// Activates the Item's effect on the given
    /// target Unit if the Item's quantity is greater
    /// than 0. Decrements the Item's quantity when
    /// used.
    /// </summary>
    /// <returns>True if the Item was used, false otherwise.</returns>
    /// <param name="targetUnit">The target Unit for this Item.</param>
    public abstract bool Use(Unit targetUnit);
}
