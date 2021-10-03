using UnityEngine;

/// <summary>
/// Abstract class representing a
/// Skill that can be used by
/// a certain level Job.
/// </summary>
public abstract class Skill
{
    /// <summary>
    /// The Resource Cost of
    /// this skill.
    /// </summary>
    public int ResourceCost
    {
        get { return resourceCost; }
    }

    /// <summary>
    /// The Level of Unit that
    /// can use this skill.
    /// </summary>
    public int UseLevel
    {
        get { return useLevel; }
    }

    /// <summary>
    /// The UnitType target for this
    /// Skill.
    /// </summary>
    public UnitType UseTarget
    {
        get { return useTarget; }
    }

    /// <summary>
    /// The Job that can use this skill.
    /// </summary>
    public Job UseJob
    {
        get { return useJob; }
    }

    /// <summary>
    /// The Number of Targets for this Skill.
    /// </summary>
    public NumberOfTargetsEnum NumberOfTargets
    {
        get { return numberOfTargets; }
    }

    private readonly int resourceCost;
    private readonly int useLevel;
    private readonly Job useJob;
    private readonly UnitType useTarget;
    private readonly NumberOfTargetsEnum numberOfTargets;

    /// <summary>
    /// Creates a new Skill.
    /// </summary>
    /// <param name="cost">The ResourceCost of this Skill.</param>
    /// <param name="level">The Level required to use this SKill.</param>
    /// <param name="job">The Job required to use this Skill.</param>
    /// <param name="target">The UnitType target of this Skill.</param>
    public Skill(int cost, int level, Job job, UnitType target, NumberOfTargetsEnum numTargets)
    {
        resourceCost = cost;
        useLevel = level;
        useJob = job;
        useTarget = target;
        numberOfTargets = numTargets;
    }
}
