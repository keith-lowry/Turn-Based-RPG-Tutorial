using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStation : MonoBehaviour
{
    private SpriteRenderer sp;

    public void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.enabled = false;
        
    }

    /**
     * Enable the Station's turn circle.
     */
    public void EnableTurnCircle()
    {
        sp.enabled = true;
    }

    /**
     * Disable the Station's turn circle.
     */
    public void DisableTurnCircle()
    {
        sp.enabled = false;
    }
}
