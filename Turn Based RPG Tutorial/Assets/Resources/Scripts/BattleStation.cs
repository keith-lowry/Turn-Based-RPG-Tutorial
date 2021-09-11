using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStation : MonoBehaviour
{
    public GameObject turnCircle;

    /**
     * Enable the Station's turn circle.
     */
    public void EnableTurnCircle()
    {
        turnCircle.SetActive(true);
    }

    /**
     * Disable the Station's turn circle.
     */
    public void DisableTurnCircle()
    {
        turnCircle.SetActive(false);
    }
}
