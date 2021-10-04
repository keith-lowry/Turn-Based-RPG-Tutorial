using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public int MaxHealth
    {
        get
        {
            //DO calculations when effects/buffs are added
            return maxHP;
        }
    }

    public int MaxResource
    {
        get
        {
            return maxRes;
        }
    }

    public int Attack
    {
        get
        {
            return at;
        }
    }

    public int MagicPower
    {
        get
        {
            return mp;
        }
    }

    public int MagicResist
    {
        get
        {
            return mr;
        }
    }

    public int Armor
    {
        get
        {
            return ar;
        }
    }

    public int Speed
    {
        get
        {
            return sp;
        }
    }

    public int CritRate
    {
        get
        {
            return cr;
        }
    }


    private int maxHP;
    private int maxRes;
    private int at;
    private int mp;
    private int ar;
    private int mr;
    private int sp;
    private int cr;

    /// <summary>
    /// Creates a new Stats object with the
    /// given length 8 array of new stats. Stats in the
    /// array should be ordered from index 0 to 7 such that:
    ///
    /// 0 - Max HP,
    /// 1 - Max Resource,
    /// 2 - Attack,
    /// 3 - Magic Power,
    /// 4 - Armor,
    /// 5 - Magic Resist,
    /// 6 - Speed,
    /// 7 - Crit Rate.
    ///
    /// Stats are set to 0 by default when given
    /// an invalid array.
    /// </summary>
    /// <param name="newStats">The size 8 array holding
    /// the desired stats.</param>
    public Stats(int[] newStats)
    {
        if (newStats == null || newStats.Length != 8)
        {
            ZeroStats();
        }
        else
        {
            maxHP = newStats[0];
            maxRes = newStats[1];
            at = newStats[2];
            mp = newStats[3];
            ar = newStats[4];
            mr = newStats[5];
            sp = newStats[6];
            cr = newStats[7];
        }
    }

    public Stats()
    {
        ZeroStats();
    }

    public Stats(Stats newStats)
    {
        if (newStats == null)
        {
            ZeroStats();
        }
        else
        {
            maxHP = newStats.MaxHealth;
            maxRes = newStats.MaxResource;
            at = newStats.Attack;
            mp = newStats.MagicPower;
            ar = newStats.Armor;
            mr = newStats.MagicResist;
            sp = newStats.Speed;
            cr = newStats.CritRate;
        }
    }

    /// <summary>
    /// Scales these stats to the given level
    /// for the given Job.
    /// </summary>
    /// <param name="level">The level to scale to.</param>
    /// <param name="job">The Job to scale for.</param>
    public void ScaleToLevel(int level, Job job)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Scales the stats to the next level of
    /// the given Job.
    /// </summary>
    /// <param name="">The Job to scale for..</param>
    public void ScaleToNextLevel(Job job)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Sets all stats to 0.
    /// </summary>
    private void ZeroStats()
    {
        maxHP = 0;
        maxRes = 0;
        at = 0;
        mp = 0;
        ar = 0;
        mr = 0;
        sp = 0;
        cr = 0;
    }
}
