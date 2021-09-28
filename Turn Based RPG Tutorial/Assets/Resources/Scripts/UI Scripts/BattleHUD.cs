using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Script for managing unit HUDS.
 */
public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;


    /// <summary>
    /// Updates all elements of the HUD
    /// to match the given Unit's stats.
    /// </summary>
    /// <param name="unit"></param>
    public void UpdateHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;

        hpSlider.maxValue = unit.stats.vitality;
        hpSlider.value = unit.CurrentHP;
    }

    /// <summary>
    /// Sets the HP slider value.
    /// </summary>
    /// <param name="hp">The unit's HP.</param>
    public void UpdateHP(int hp)
    {
        hpSlider.value = hp;
    }

    /// <summary>
    /// Sets the HP slider max value.
    /// </summary>
    /// <param name="maxHP">The unit's max HP.</param>
    public void UpdateMaxHP(int maxHP)
    {
        hpSlider.maxValue = maxHP;
    }

    /// <summary>
    /// Sets the level text.
    /// </summary>
    /// <param name="lvl">The unit's current level.</param>
    public void UpdateLevel(int lvl)
    {
        levelText.text = "Lvl " + lvl;
    }

    /// <summary>
    /// Move the BattleHUD to the given unit's
    /// location in worldspace.
    /// </summary>
    /// <param name="unit"></param>
    public void MoveToUnit(Unit unit)
    {
        throw new NotImplementedException();
    }


}
