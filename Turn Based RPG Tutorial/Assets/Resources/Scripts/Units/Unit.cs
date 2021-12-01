using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.PlayerLoop;

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

    public UnitType type;
    public Job job;
    public Class proff;

    /**
     * The Unit's current level.
     */
    public int unitLevel;

    /// <summary>
    /// The Unit's current HP.
    /// </summary>
    public int CurrentHP
    {
        get { return currentHP;}
    }

    /// <summary>
    /// The Unit's current amount
    /// of Resource.
    /// </summary>
    public int CurrentResource
    {
        get { return currentResource; }
    }

    /// <summary>
    /// The Unit's current combat stats.
    /// </summary>
    public Stats Stats
    {
        get
        {
            return stats;
        }
    }

    /// <summary>
    /// The type of Resource this Unit uses.
    /// </summary>
    public ResourceType ResourceType
    {
        get { return resourceType; }
    }

    public Transform head;

    private Stats stats;
    private ResourceType resourceType;
    private int currentResource;
    private int currentHP;

    private UnitHUD hud;

    private BattleStation homeStation;


    public void Awake()
    {
        stats = new Stats(Levelling.GetBaseStats(job));

        currentResource = stats.MaxResource;
        currentHP = stats.MaxHealth;
        resourceType = SkillsDatabase.GetResourceType(job);
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
            UpdateHUD();
            return true;
        }

        currentHP -= dmg; 
        UpdateHUD();
        return false;
    }

    /// <summary>
    /// Heals the Unit a certain amount
    /// if they are not already at max
    /// health.
    /// </summary>
    /// <param name="heal">The amount to heal.</param>
    /// <returns>True if the Unit was healed, false otherwise.</returns>
    public bool Heal(int heal)
    {
        //At full health already
        if (currentHP == stats.MaxHealth)
        {
            return false;
        }

        currentHP += heal;

        if (currentHP > stats.MaxHealth)
        {
            currentHP = stats.MaxHealth;
        }

        UpdateHUD();

        return true;

    }

    public void Die()
    {
        Destroy(hud.gameObject);
        Destroy(this.gameObject);
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
            hud.SetUpHUD(this);

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
            UpdateHUDPosition();
        }
    }

    /// <summary>
    /// Updates the HUD to match the
    /// Unit's current condition.
    /// </summary>
    private void UpdateHUD()
    {
        if (hud != null)
        {
            hud.SetHP(currentHP);
            hud.SetJobAndLevel(job, unitLevel);
            hud.SetMaxHP(stats.MaxHealth);
        }
    }

    /// <summary>
    /// Moves the HUD to the Unit's
    /// head.
    /// </summary>
    private void UpdateHUDPosition()
    {
        if (hud != null)
        {
            hud.MoveToHead();
        }
    }
    #endregion
}
