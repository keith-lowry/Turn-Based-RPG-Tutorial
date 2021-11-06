using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Container for a Profession's title, skills, base stats,
/// and stat growth rates.
/// </summary>
[CreateAssetMenu(fileName = "New Profession", menuName = "Profession")]
public class Profession : ScriptableObject
{
    public string title;

    public List<Skill> skills;
    public StatsRaw baseStatsRaw;
    public StatsRaw growthRatesRaw;

    /// <summary>
    /// Container for starting Stats and
    /// Stat growth rates.
    /// </summary>
    [System.Serializable]
    public class StatsRaw
    {
        public int maxHealth;
        public int maxResource;
        public int attack;
        public int magicPower;
        public int armor;
        public int magicResist;
        public int speed;
        public int critRate;
    }
}
