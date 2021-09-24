using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Script for managing unit HUDS.
 */
public class BattleHUD : MonoBehaviour
{
    private Text nameText;
    private Text levelText;
    private Slider hpSlider;

    public void Awake()
    {
        GameObject name = transform.GetChild(1).gameObject;
        GameObject level = transform.GetChild(2).gameObject;
        GameObject hp = transform.GetChild(3).gameObject;

        nameText = name.GetComponent<Text>();
        levelText = level.GetComponent<Text>();
        hpSlider = hp.GetComponent<Slider>();

        if (nameText == null || levelText == null || hpSlider == null)
        {
            Debug.Log("The order of the Battle Hud's children was changed. The " +
                      "order should be: ");
            Debug.Log("0 - Background Image");
            Debug.Log("1 - Name Text");
            Debug.Log("2 - Level Text");
            Debug.Log("3 - HP Slider");
        }
    }

    public void SetUpHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;

        hpSlider.maxValue = unit.stats.vitality;
        hpSlider.value = unit.CurrentHP;
    }

    /**
     * Sets the HP slider value.
     */
    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void SetLevel(int lvl)
    {
        levelText.text = "Lvl " + lvl;
    }
}
