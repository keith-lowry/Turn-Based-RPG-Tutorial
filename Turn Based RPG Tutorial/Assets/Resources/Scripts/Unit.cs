using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

/**
 * Script containing properties of
 * Units that can be used in combat.
 */
public class Unit : MonoBehaviour
{
    /**
     * The Unit's name.
     */
    public string unitName;

    /**
     * The Unit's current level.
     */
    public int unitLevel;

    public Jobs.JobsEnum job;

    /// <summary>
    /// The Unit's current HP.
    /// </summary>
    private int currentHP;

    /// <summary>
    /// The Unit's current HP.
    /// </summary>
    public int CurrentHP
    {
        get { return currentHP;}
    }

    public UnitStats baseStats;

    public UnitStats stats;
    

    public void Awake()
    {
        stats = new UnitStats(baseStats.vitality, baseStats.resource, 
            baseStats.intelligence, baseStats.strength, 
            baseStats.magicResist, baseStats.armor, baseStats.speed);
        currentHP = stats.vitality;
    }

    /**
     * Makes the unit take damage.
     *
     * Returns true if the unit dies
     * after taking damage.
     */
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Heals the player for
    /// a certain amount.
    /// </summary>
    /// <param name="heal"></param>
    public void Heal(int heal)
    {
        currentHP += heal;

        if (currentHP > stats.vitality)
        {
            currentHP = stats.vitality;
        }
    }

    /**
     * Struct holding the Unit's stats.
     */
    [System.Serializable]
    public class UnitStats
    {
        public int vitality;
        public int resource;
        public int intelligence;
        public int strength;
        public int magicResist;
        public int armor;
        public int speed;

        public UnitStats(int v, int r, int i, int s, int mr, int a, int sp)
        {
            vitality = v;
            resource = r;
            intelligence = i;
            strength = s;
            magicResist = mr;
            armor = a;
            speed = sp;
        }
    }
}
