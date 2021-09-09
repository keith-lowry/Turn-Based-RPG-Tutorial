using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script containing properties of
 * Units that can be used in combat.
 */
public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;

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
}
