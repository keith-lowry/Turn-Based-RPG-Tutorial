using System.Collections;
using System.Collections.Generic;
using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;

public class DaggerToss : SingleTargetSkill
{
    /// <summary>
    /// The DaggerToss skill instance.
    /// </summary>
    public static DaggerToss Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DaggerToss();
            }

            return _instance;
        }
    }

    private static DaggerToss _instance;

    private static readonly string skillName = "Dagger Toss";
    private static readonly int cost = 30;
    private static readonly int level = 1;
    private static readonly Job job = Job.Assassin;
    private static readonly TargetType targetType = TargetType.Foe;

    public DaggerToss() : base(skillName, cost, level, job, targetType) { }

    public override void Activate(Unit userUnit, Unit targetUnit)
    {
        throw new System.NotImplementedException();
    }
}
