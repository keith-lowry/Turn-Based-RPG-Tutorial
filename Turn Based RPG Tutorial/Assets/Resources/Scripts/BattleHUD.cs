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

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;

        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.CurrentHP;
    }

    /**
     * Sets the HP slider value.
     */
    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
