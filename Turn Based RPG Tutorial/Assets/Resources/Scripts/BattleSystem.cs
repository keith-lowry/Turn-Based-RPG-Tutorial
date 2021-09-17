using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using Random = System.Random;

/**
 * Enum representing different states
 * in battle.
 */
public enum BattleState
{
    START, PLAYERTURN, ENEMYTURN, WON, LOST
}

public class BattleSystem : MonoBehaviour
{
    #region Public Fields
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public BattleStation playerStation; //location of player on battlefield
    public BattleStation enemyStation; //location of enemy on battlefield

    public ActionScreen actionScreen;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;
    #endregion

    #region Private Fields
    private static readonly string[] battleStartDialogue = {" approaches!",
        " corners your party!", " ambushes you!"};
    private Unit playerUnit;
    private Unit enemyUnit;
    private HealthPotion playerPotion;
    #endregion

    #region Set Up

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    //Initialize Battle gameobjects and fields
    private IEnumerator SetUpBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab,
            playerStation.gameObject.transform);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab,
            enemyStation.gameObject.transform);
        enemyUnit = enemyGO.GetComponent<Unit>();

        playerPotion = playerGO.GetComponent<HealthPotion>();

        //Start Dialogue
        actionScreen.SetMode(ActionScreenMode.Dialogue);
        actionScreen.SetDialogue(enemyUnit.unitName + GetStartDialogue());

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f); //wait then start player turn

        //initiate player turn
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    #endregion

    #region Turn Actions
    private IEnumerator PlayerAttack()
    {
        actionScreen.SetMode(ActionScreenMode.Dialogue);

        // Damage the enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.stats.strength);

        enemyHUD.SetHP(enemyUnit.CurrentHP);
        actionScreen.SetDialogue("The attack is successful!");

        yield return new WaitForSeconds(2f);

        // Check if enemy is dead
        if (isDead)
        {
            //End the battle
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            //Enemy turn
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

        }
    }

    private IEnumerator UseItem()
    {
        yield return null;
    }

    private IEnumerator Sorry()
    {
        actionScreen.SetMode(ActionScreenMode.Dialogue);
        actionScreen.SetDialogue("I can't let you do that");

        yield return new WaitForSeconds(1.5f);

        actionScreen.SetMode(ActionScreenMode.Actions);

    }

    #endregion

    #region OnClick Events
    public void OnClickUnimplemented()
    {
        StartCoroutine(Sorry());
    }

    public void OnClickItems()
    {
        actionScreen.SetMode(ActionScreenMode.Items);
    }

    public void OnClickConsumable(ConsumableButton c)
    {
        Consumables type = c.consumableType;

        if (type.Equals(Consumables.HealthPotion))
        {
            playerPotion.Use(playerUnit, enemyUnit);
        }
        playerHUD.hpSlider.value = playerUnit.CurrentHP;

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    /**
    * Called when player clicks attack button.
    */
    public void OnClickAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
        state = BattleState.ENEMYTURN;
    }
    #endregion


    /**
     * Update UI for player's turn.
     */
    private void PlayerTurn()
    {
        actionScreen.SetMode(ActionScreenMode.Actions);

        playerStation.EnableTurnCircle();
        enemyStation.DisableTurnCircle();
    }

    private IEnumerator EnemyTurn()
    {
        playerStation.DisableTurnCircle();
        enemyStation.EnableTurnCircle();

        actionScreen.SetMode(ActionScreenMode.Dialogue);
        actionScreen.SetDialogue(enemyUnit.unitName + " attacks!");

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.stats.strength);

        playerHUD.SetHP(playerUnit.CurrentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    private void EndBattle()
    {
        if (state == BattleState.WON)
        {
            actionScreen.SetDialogue("You won!");
        }
        else if (state == BattleState.LOST)
        {
            actionScreen.SetDialogue("You lost");
        }
    }

    #region Helper Methods
    /**
     * Get a random string of dialogue
     * for battle start.
     */
    private String GetStartDialogue()
    {
        Random r = new Random();

        int i = r.Next(battleStartDialogue.Length);

        return battleStartDialogue[i];
    }


    #endregion

}
