using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCircle : MonoBehaviour
{
    private GameObject turnCircle;

    // Start is called before the first frame update
    void Start()
    {
        turnCircle = this.gameObject;
    }

    /**
     * Enable this turn circle.
     */
    public void Enable()
    {
        turnCircle.SetActive(true);
    }

    /**
     * Disable this turn circle.
     */
    public void Disable()
    {
        turnCircle.SetActive(false);
    }
}
