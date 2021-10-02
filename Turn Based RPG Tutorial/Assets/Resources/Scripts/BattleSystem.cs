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
    #endregion

    #region Canvases and UI
    public ActionScreen actionScreen;
    public GameObject hudPrefab;
    public Transform hudCanvas;
    #endregion

    #region Private Fields
    private BattleState state;
    private static readonly string[] battleStartDialogue = {" approaches!",
        " corners your party!", " ambushes you!"};
    private Unit playerUnit;
    private Unit enemyUnit;
    private Inventory partyInventory;
    #endregion

    #region Set Up

    // Start is called before the first frame update
    void Start()
    {
        partyInventory = Inventory.Instance;
        SetBattleState(BattleState.START);
    }

    //Initialize Battle gameobjects and fields
    private IEnumerator SetUpBattle()
    {
        //Add 2 health potions to inventory
        partyInventory.AddItem(ItemType.HealthPotion, 2);

        //Add units and huds
        playerUnit = Instantiate(playerPrefab,
            Vector3.zero, Quaternion.identity).GetComponent<Unit>();
        UnitHUD playerHUD = Instantiate(hudPrefab, Vector3.zero,
            Quaternion.identity).GetComponent<UnitHUD>();

        playerHUD.transform.SetParent(hudCanvas, false); //move player HUD to canvas
        playerUnit.SetHUD(playerHUD); //set player's HUD
        playerUnit.SetHomeStation(playerStation); //set player's home station
        playerUnit.MoveToHomeStation(); //move player to home station

        enemyUnit = Instantiate(enemyPrefab,
            Vector3.zero, Quaternion.identity).GetComponent<Unit>();
        UnitHUD enemyHUD = Instantiate(hudPrefab, Vector3.zero, 
            Quaternion.identity).GetComponent<UnitHUD>();

        enemyHUD.transform.SetParent(hudCanvas, false);
        enemyUnit.SetHUD(enemyHUD);
        enemyUnit.SetHomeStation(enemyStation);
        enemyUnit.MoveToHomeStation();

        //Start Dialogue
        actionScreen.SetMode(ActionScreenMode.Dialogue);
        actionScreen.SetDialogue(enemyUnit.unitName + GetStartDialogue());

        yield return new WaitForSeconds(2f); //wait then start player turn

        //initiate player turn
        SetBattleState(BattleState.PLAYERTURN);
    }

    #endregion

    #region Turn Actions
    private IEnumerator PlayerAttack()
    {
        actionScreen.SetMode(ActionScreenMode.Dialogue);

        // Damage the enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.Stats.Attack);

        actionScreen.SetDialogue("The attack is successful!");

        yield return new WaitForSeconds(2f);

        // Check if enemy is dead
        if (isDead)
        {
            //End the battle
            SetBattleState(BattleState.WON);
        }
        else
        {
            //Enemy turn
            SetBattleState(BattleState.ENEMYTURN);
        }
    }

    private IEnumerator UseItem(Item item)
    {
        bool wasUsed = item.Use(playerUnit, enemyUnit);

        if (wasUsed)
        {
            String dialogue = item.GetUseDialogue(playerUnit, enemyUnit);
            actionScreen.SetMode(ActionScreenMode.Dialogue);
            actionScreen.SetDialogue(dialogue);
            yield return new WaitForSeconds(2f);
            SetBattleState(BattleState.ENEMYTURN);
        }
        else
        {
            String dialogue = item.GetNonUseDialogue();
            actionScreen.SetMode(ActionScreenMode.Dialogue);
            actionScreen.SetDialogue(dialogue);
            yield return new WaitForSeconds(2f);
            actionScreen.SetMode(ActionScreenMode.Items);
        }
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

    /// <summary>
    /// Method called when an Item
    /// button is clicked.
    /// </summary>
    /// <param name="c"></param>
    public void OnClickItem(ItemButton button)
    {
        ItemType type = button.type;
        Item item = partyInventory.GetItem(type);
        if (item != null)
        {
            StartCoroutine(UseItem(item));
        }
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

        bool isDead = playerUnit.TakeDamage(enemyUnit.Stats.Attack);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            SetBattleState(BattleState.LOST);
        }
        else
        {
            SetBattleState(BattleState.PLAYERTURN);
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

    /// <summary>
    /// Sets the battlestate and
    /// updates the battle to fit the
    /// new state.
    /// </summary>
    /// <param name="newState">The new battlestate.</param>
    private void SetBattleState(BattleState newState)
    {
        //TODO: SetBattleState

        switch (newState)
        {
            case BattleState.PLAYERTURN:
            {
                state = BattleState.PLAYERTURN;
                PlayerTurn(); //start player turn
                break;
            }
            case BattleState.ENEMYTURN:
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
                break;
            }
            case BattleState.LOST:
            {
                state = BattleState.LOST;
                EndBattle();
                break;
            }
            case BattleState.START:
            {
                state = BattleState.START;
                StartCoroutine(SetUpBattle()); //set up battle
                break;
            }
            case BattleState.WON:
            {
                state = BattleState.WON;
                EndBattle();
                break;
            }
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
