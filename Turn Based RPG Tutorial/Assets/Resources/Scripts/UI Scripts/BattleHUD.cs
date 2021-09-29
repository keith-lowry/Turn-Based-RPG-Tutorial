using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;

/**
 * Script for managing unit HUDS.
 */
public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;

    private Transform head;
    private static readonly float headOffsetY = 0.10f;


    /// <summary>
    /// Updates all elements of the HUD
    /// to match the given Unit's stats.
    /// </summary>
    /// <param name="unit"></param>
    public void PopulateHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;

        hpSlider.maxValue = unit.stats.vitality;
        hpSlider.value = unit.CurrentHP;
        head = unit.head;

        MoveToHead();
    }

    /// <summary>
    /// Sets the HP slider value.
    /// </summary>
    /// <param name="hp">The unit's HP.</param>
    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    /// <summary>
    /// Sets the HP slider max value.
    /// </summary>
    /// <param name="maxHP">The unit's max HP.</param>
    public void SetMaxHP(int maxHP)
    {
        hpSlider.maxValue = maxHP;
    }

    /// <summary>
    /// Sets the level text.
    /// </summary>
    /// <param name="lvl">The unit's current level.</param>
    public void SetLevel(int lvl)
    {
        levelText.text = "Lvl " + lvl;
    }

    /// <summary>
    /// Move the BattleHUD to the given unit's
    /// location in worldspace.
    /// </summary>
    /// <param name="unit"></param>
    public void MoveToHead()
    {
        UnityEngine.Vector3 newPosition = head.position;
        newPosition.y += BattleHUD.headOffsetY;

        transform.SetPositionAndRotation(newPosition, Quaternion.identity);
    }


}
