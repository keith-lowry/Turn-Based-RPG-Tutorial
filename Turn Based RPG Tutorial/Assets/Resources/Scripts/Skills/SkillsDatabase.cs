using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class holding Utility
/// methods relating to Unit Skills.
/// </summary>
public static class SkillsDatabase
{
    /// <summary>
    /// Gets the Resource type that the given Job uses.
    /// </summary>
    /// <param name="job">The Job.</param>
    /// <returns>The Job's resource type for Skills.</returns>
    public static ResourceType GetResourceType(Job job)
    {
        switch (job)
        {
            case Job.Assassin:
                return ResourceType.Stamina;
            case Job.Bandit:
                return ResourceType.Stamina;
            case Job.Berserker:
                return ResourceType.Fury;
            case Job.Crook:
                return ResourceType.Stamina;
            case Job.Herbalist:
                return ResourceType.Stamina;
            case Job.Mage:
                return ResourceType.Mana;
            case Job.Marksman:
                return ResourceType.Fury;
            case Job.Pirate:
                return ResourceType.Fury;
            case Job.Sage:
                return ResourceType.Mana;
            default:
                return ResourceType.Stamina;
        }
    }
}
