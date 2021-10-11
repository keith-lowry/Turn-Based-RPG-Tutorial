/// <summary>
/// Abstract class representing a Skill
/// whose effect activates on one target only.
/// </summary>
public abstract class SingleTargetSkill : Skill
{

    /// <summary>
    /// Creates a new SingleTargetSkill.
    /// </summary>
    /// <param name="cost">The Resource Cost of this Skill.</param>
    /// <param name="level">The Level required to use this Skill.</param>
    /// <param name="job">The Job required to use this Skill.</param>
    /// <param name="targetType">The UnitType target of this Skill.</param>
    /// <param name="name">The name of this Skill.</param>
    public SingleTargetSkill(string name, int cost, int level, Job job, TargetType targetType) : 
        base(name, cost, level, job, targetType, TargetCount.Single) {}

    /// <summary>
    /// Activates the Skill's effect.
    /// </summary>
    /// <param name="userStats">The Unit using this Skill.</param>
    /// <param name="targetUnit">The Target of this Skill.</param>
    public abstract void Activate(Unit userUnit, Unit targetUnit);
}
