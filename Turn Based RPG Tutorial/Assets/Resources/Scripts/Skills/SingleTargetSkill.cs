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
    /// <param name="target">The UnitType target of this Skill.</param>
    public SingleTargetSkill(int cost, int level, Job job, UnitType target) : 
        base(cost, level, job, target, NumberOfTargetsEnum.Single) {}

    /// <summary>
    /// Activates the Skill's effect.
    /// </summary>
    /// <param name="userStats">The Unit using this Skill.</param>
    /// <param name="targetUnit">The Target of this Skill.</param>
    public abstract void Activate(Unit userUnit, Unit targetUnit);
}
