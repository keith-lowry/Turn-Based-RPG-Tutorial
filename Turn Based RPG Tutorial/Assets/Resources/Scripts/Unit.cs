using System.Collections;
using System.Collections.Generic;
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

    /**
     * Amount of damage the Unit's
     * attacks deal.
     */
    public int damage;

    /**
     * Maximum amount of HP the Unit
     * can have.
     */
    public int maxHP;

    /// <summary>
    /// The Unit's current HP.
    /// </summary>
    public int CurrentHP
    {
        get { return currentHP; }
    }

    /// <summary>
    /// The Unit's current HP.
    /// </summary>
    private int currentHP;

    public void Awake()
    {
        currentHP = maxHP;
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

        if (CurrentHP <= 0)
        {
            return true;
        }

        return false;
    }
}
