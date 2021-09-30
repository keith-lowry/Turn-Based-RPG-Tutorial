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
    public int CurrentHP
    {
        get { return currentHP;}
    }

    public UnitStats baseStats;

    public UnitStats stats;

    public Transform head;

    /// <summary>
    /// The Unit's current HP.
    /// </summary>
    private int currentHP;

    private UnitHUD hud;

    private BattleStation homeStation;


    public void Awake()
    {
        stats = new UnitStats(baseStats.vitality, baseStats.resource,
            baseStats.intelligence, baseStats.strength,
            baseStats.magicResist, baseStats.armor, baseStats.speed,
            baseStats.critRate);


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
        if ((currentHP - dmg) <= 0)
        {
            currentHP = 0;
            hud.SetHP(currentHP); //update hud
            return true;
        }

        currentHP -= dmg; 
        hud.SetHP(currentHP); //update hud
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

        if (hud != null)
        { 
            hud.SetHP(currentHP); //update hud
        }
        
    }

    #region Utility Methods
    /// <summary>
    /// Sets the Unit's HUD.
    /// </summary>
    /// <param name="newHud">The Unit's HUD.</param>
    public void SetHUD(UnitHUD newHud)
    {
        if (newHud != null)
        {
            hud = newHud;
            hud.PopulateHUD(this);

        }
    }

    /// <summary>
    /// Sets the Unit's home station
    /// in the battlefield.
    /// </summary>
    /// <param name="home">The Unit's home station.</param>
    public void SetHomeStation(BattleStation home)
    {
        homeStation = home;
    }

    /// <summary>
    /// Moves the Unit to their home station
    /// on the battlefield.
    /// </summary>
    public void MoveToHomeStation()
    {
        MoveToStation(homeStation);
    }

    /// <summary>
    /// Moves the Unit to the given station on
    /// the battlefield.
    /// </summary>
    /// <param name="station"></param>
    public void MoveToStation(BattleStation station)
    {
        if (station != null)
        {
            transform.SetPositionAndRotation(station.transform.position,
                Quaternion.identity);
            hud.MoveToHead();
        }
    }
    #endregion


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
        public int critRate;

        public UnitStats(int v, int r, int i, int s, int mr, int a, int sp, int cr)
        {
            vitality = v;
            resource = r;
            intelligence = i;
            strength = s;
            magicResist = mr;
            armor = a;
            speed = sp;
            critRate = cr;
        }
    }
}
