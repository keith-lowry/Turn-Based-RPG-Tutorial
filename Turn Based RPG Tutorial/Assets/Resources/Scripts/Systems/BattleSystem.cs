using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
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

    public float dialogueDelay;
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
        actionScreen.gameObject.SetActive(true);
        actionScreen.SetMode(ActionScreenMode.Dialogue);
        actionScreen.SetDialogue(enemyUnit.unitName + GetStartDialogue());

        yield return new WaitForSeconds(dialogueDelay); //wait then start player turn

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

        yield return new WaitForSeconds(dialogueDelay);

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

    /// <summary>
    /// Uses the given Item on the given target.
    /// </summary>
    /// <param name="target">The UnitType of the target.</param>
    /// <param name="item">The Item to be used.</param>
    /// <returns></returns>
    private IEnumerator UseItem(UnitAllegiance target, Item item)
    {
        switch (item.TargetCount)
        {
            //MultiTargetItem
            case TargetCount.Multiple:
                break;

            //SingleTargetItem
            case TargetCount.Single:
                Unit targetUnit = playerUnit;

                if (target == UnitAllegiance.Enemy)
                {
                    targetUnit = enemyUnit;
                }

                SingleTargetItem i = (SingleTargetItem) item;
                bool wasUsed = i.Use(targetUnit);

                if (wasUsed)
                {
                    String dialogue = i.GetUseDialogue();
                    actionScreen.SetMode(ActionScreenMode.Dialogue);
                    actionScreen.SetDialogue(dialogue);
                    yield return new WaitForSeconds(dialogueDelay);
                    SetBattleState(BattleState.ENEMYTURN);
                }
                else
                {
                    String dialogue = i.GetFailedUseDialogue();
                    actionScreen.SetMode(ActionScreenMode.Dialogue);
                    actionScreen.SetDialogue(dialogue);
                    yield return new WaitForSeconds(dialogueDelay);
                    actionScreen.SetMode(ActionScreenMode.Items);
                }

                break;
        }
    }

    private IEnumerator Sorry()
    {
        actionScreen.SetMode(ActionScreenMode.Dialogue);
        actionScreen.SetDialogue("I can't let you do that");

        yield return new WaitForSeconds(dialogueDelay);

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
            UnitAllegiance userUnitAllegiance = UnitAllegiance.Player;
            TargetType targetType = item.TargetType;
            UnitAllegiance targetUnitAllegiance = DetermineTargetUnitType(userUnitAllegiance, 
                targetType);
            StartCoroutine(UseItem(targetUnitAllegiance, item));
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
            actionScreen.SetDialogue("");
            StartCoroutine(YouLost());
        }
    }

    /// <summary>
    /// Dramatic ending for the Level when the Player loses.
    /// Reloads Level.
    /// </summary>
    /// <returns></returns>
    private IEnumerator YouLost()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1.5f);
        actionScreen.SetDialogue("You");
        yield return new WaitForSecondsRealtime(0.7f);
        actionScreen.SetDialogue("You L");
        yield return new WaitForSecondsRealtime(0.7f);
        actionScreen.SetDialogue("You Lo");
        yield return new WaitForSecondsRealtime(0.7f);
        actionScreen.SetDialogue("You Los");
        yield return new WaitForSecondsRealtime(0.7f);
        actionScreen.SetDialogue("You Lost");
        yield return new WaitForSecondsRealtime(0.7f);
        playerUnit.Die();
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(0);//reload level
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Sets the battlestate and
    /// updates the battle to fit the
    /// new state.
    /// </summary>
    /// <param name="newState">The new battlestate.</param>
    private void SetBattleState(BattleState newState)
    {
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

    /// <summary>
    /// Determines the UnitType of the Target
    /// of an Item or Skill based on the
    /// Item or Skill's user UnitType and the Item or Skill's
    /// TargetType.
    /// </summary>
    /// <param name="userUnitAllegiance">The UnitType of the User.</param>
    /// <param name="targetType">The TargetType of the Item/Skill.</param>
    /// <returns>The UnitType of the target of this Item or Skill.</returns>
    private UnitAllegiance DetermineTargetUnitType(UnitAllegiance userUnitAllegiance, TargetType targetType)
    {
        switch (userUnitAllegiance)
        {
            case UnitAllegiance.Player:
                if (targetType == TargetType.Foe)
                {
                    return UnitAllegiance.Enemy;
                }

                return UnitAllegiance.Player;

            case UnitAllegiance.Enemy:
                if (targetType == TargetType.Foe)
                {
                    return UnitAllegiance.Player;
                }

                return UnitAllegiance.Enemy;
        }

        return userUnitAllegiance;
    }

    #endregion

}
