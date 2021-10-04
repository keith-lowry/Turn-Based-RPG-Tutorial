using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;

/**
 * Script for managing unit HUDS.
 */
public class UnitHUD : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Slider hpSlider;
    public Slider resourceSlider;
    public Image resourceFill;

    public Color furyColor;
    public Color manaColor;
    public Color staminaColor;

    private Transform head;
    private static readonly float headOffsetY = 0.10f;


    /// <summary>
    /// Updates all elements of the HUD
    /// to match the given Unit's stats, and then
    /// moves it to the Unit's head.
    /// </summary>
    /// <param name="unit">The Unit this HUD
    /// should display information about.</param>
    public void SetUpHUD(Unit unit)
    {
        SetJobAndLevel(unit.job, unit.unitLevel);

        SetMaxHP(unit.Stats.MaxHealth);
        SetHP(unit.CurrentHP);

        SetMaxResource(unit.Stats.MaxResource);
        SetResource(unit.CurrentResource);
        SetResourceType(unit.ResourceType);

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
    /// <param name="maxHP">The Unit's max HP.</param>
    public void SetMaxHP(int maxHP)
    {
        hpSlider.maxValue = maxHP;
    }

    /// <summary>
    /// Sets the Job and Level text.
    /// </summary>
    /// <param name="name">The Unit's Job.</param>
    /// <param name="lvl">The Unit's current level.</param>
    public void SetJobAndLevel(Job job, int lvl)
    {
        text.text = job.ToString() + " Lvl " + lvl;
    }

    /// <summary>
    /// Sets the Resource slider's current value.
    /// </summary>
    /// <param name="resource">Current Resource value.</param>
    public void SetResource(int resource)
    {
        resourceSlider.value = resource;
    }

    /// <summary>
    /// Sets the Resource slider's max value.
    /// </summary>
    /// <param name="maxResource">Max Resource value.</param>
    public void SetMaxResource(int maxResource)
    {
        resourceSlider.maxValue = maxResource;
    }

    /// <summary>
    /// Sets the Resource Bar's color based
    /// on the ResourceType.
    /// </summary>
    /// <param name="type">The ResourceType.</param>
    public void SetResourceType(ResourceType type)
    {
        switch (type)
        {
            case ResourceType.Fury:
                resourceFill.color = furyColor;
                break;
            case ResourceType.Mana:
                resourceFill.color = manaColor;
                break;
            case ResourceType.Stamina:
                resourceFill.color = staminaColor;
                break;
        }
    }

    /// <summary>
    /// Move the BattleHUD to its associated
    /// Unit's head.
    /// </summary>
    public void MoveToHead()
    {
        UnityEngine.Vector3 newPosition = head.position;
        newPosition.y += UnitHUD.headOffsetY;

        transform.SetPositionAndRotation(newPosition, Quaternion.identity);
    }


}
