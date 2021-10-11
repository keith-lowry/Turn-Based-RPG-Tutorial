using UnityEngine;

/// <summary>
/// Abstract class representing a
/// Skill that can be used by
/// a certain level Job.
/// </summary>
public abstract class Skill : ITargetable
{
    /// <summary>
    /// The UnitType target for this
    /// Skill.
    /// </summary>
    public TargetType TargetType
    {
        get { return targetType; }
    }

    /// <summary>
    /// The Number of Targets for this Skill.
    /// </summary>
    public TargetCount TargetCount
    {
        get { return numberOfTargets; }
    }

    /// <summary>
    /// This Skill's name.
    /// </summary>
    public string SkillName
    {
        get { return skillName; }
    }

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
    /// The Job that can use this skill.
    /// </summary>
    public Job UseJob
    {
        get { return useJob; }
    }

    private readonly TargetType targetType;
    private readonly TargetCount numberOfTargets;
    private readonly string skillName;
    private readonly int resourceCost;
    private readonly int useLevel;
    private readonly Job useJob;

    /// <summary>
    /// Creates a new Skill.
    /// </summary>
    /// <param name="cost">The ResourceCost of this Skill.</param>
    /// <param name="level">The Level required to use this SKill.</param>
    /// <param name="job">The Job required to use this Skill.</param>
    /// <param name="targetType">The UnitType target of this Skill.</param>
    /// <param name="numTargets">The number of targets for this Skill.</param>
    /// <param name="name">The name of the Skill.</param>
    public Skill(string name, int cost, int level, Job job, TargetType target, TargetCount numTargets)
    {
        skillName = name;
        resourceCost = cost;
        useLevel = level;
        useJob = job;
        targetType = target;
        numberOfTargets = numTargets;
    }
}
