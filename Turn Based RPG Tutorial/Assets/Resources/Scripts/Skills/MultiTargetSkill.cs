/// <summary>
/// Abstract class representing a Skill whose effect
/// activates on multiple targets.
/// </summary>
public abstract class MultiTargetSkill : Skill
{
    /// <summary>
    /// Creates a new MultiTargetSkill.
    /// </summary>
    /// <param name="cost">The Resource Cost of the Skill.</param>
    /// <param name="level">The Level required to use this Skill.</param>
    /// <param name="job">The Job required to use this Skill.</param>
    /// <param name="target">The UnitType target of this Skill.</param>
    public MultiTargetSkill(int cost, int level, Job job, UnitType target) : 
        base(cost, level, job, target, NumberOfTargetsEnum.Multiple) {}

    /// <summary>
    /// Activates the Skill's effect.
    /// </summary>
    /// <param name="userUnit">The Unit using this Skill.</param>
    /// <param name="targetUnits">The Targets of this Skill.</param>
    public abstract void Activate(Unit userUnit, Unit[] targetUnits);
}
