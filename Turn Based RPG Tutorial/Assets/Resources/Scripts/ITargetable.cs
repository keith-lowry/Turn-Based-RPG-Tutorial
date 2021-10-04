using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface representing some behavior
/// that can target a certain UnitType
/// and number of Unit Targets.
/// </summary>
public interface ITargetable
{
    /// <summary>
    /// The Type of Unit that can
    /// be targetted.
    /// </summary>
    public TargetType TargetType
    {
        get;
    }

    /// <summary>
    /// The number of Targets.
    /// </summary>
    public NumberOfTargetsEnum NumberOfTargets
    {
        get;
    }

}
