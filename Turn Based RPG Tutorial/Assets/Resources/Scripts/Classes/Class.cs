using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Container for a Class's title, skills, base stats,
/// and stat growth rates.
///
/// A Class is a trait of Units that determines their stats
/// and abilities for combat.
/// </summary>
[CreateAssetMenu(fileName = "New Class", menuName = "Class")]
public class Class : ScriptableObject
{
    public string Title
    {
        get => title;
    }

    public Skill[] Skills
    {
        get => skills.ToArray();
    }

    public StatsRaw BaseStats
    {
        get => baseStatsRaw;
    }

    public StatsRaw GrowthRates
    {
        get => growthRatesRaw;
    }

    [SerializeField] private string title; //Class Title
    [SerializeField] private List<Skill> skills; //All Possible Skills
    [SerializeField] private StatsRaw baseStatsRaw; //Level 1 Base Stats
    [SerializeField] private StatsRaw growthRatesRaw; //Levelling Growth Rates

    /// <summary>
    /// Container for starting Stats and
    /// Stat growth rates.
    /// </summary>
    [System.Serializable]
    public class StatsRaw
    {
        public int MaxHealth
        {
            get => maxHealth;
        }

        public int MaxResource
        {
            get => maxResource;
        }

        public int Attack
        {
            get => attack;
        }

        public int MagicPower
        {
            get => magicPower;
        }

        public int Armor
        {
            get => armor;
        }

        public int MagicResist
        {
            get => magicResist;
        }

        public int Speed
        {
            get => speed;
        }

        public int CritRate
        {
            get => critRate;
        }
        
        [SerializeField] private int maxHealth;
        [SerializeField] private int maxResource;
        [SerializeField] private int attack;
        [SerializeField] private int magicPower;
        [SerializeField] private int armor;
        [SerializeField] private int magicResist;
        [SerializeField] private int speed;
        [SerializeField] private int critRate;
    }
}
