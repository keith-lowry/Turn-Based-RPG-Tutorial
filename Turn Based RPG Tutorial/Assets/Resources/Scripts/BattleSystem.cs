using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerStation; //location of player on battlefield
    public Transform enemyStation; //location of enemy on battlefield

    private Unit playerUnit;
    private Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    //Initialize Battle gameobjects and fields
    private IEnumerator SetUpBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName;

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f); //wait then start player turn

        //initiate player turn
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        // Damage the enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!"; 
        
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

    private IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn(); }
    }

    private void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You've won!";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You lost";
        }
    }

    /**
     * Update dialogue text for
     * player's turn.
     */
    private void PlayerTurn()
    {
        dialogueText.text = "Choose an action: ";
    }

    /**
     * Called when player clicks attack button.
     */
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
        state = BattleState.ENEMYTURN;
    }
}
