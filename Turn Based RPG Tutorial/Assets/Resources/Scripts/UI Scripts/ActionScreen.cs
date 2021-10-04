using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum ActionScreenMode
    {
        Dialogue, Actions, Skills, Items
    }

public class ActionScreen : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject actionButtons;
    public GameObject skillsButtons;
    public GameObject itemsButtons;

    private ActionScreenMode mode;
    private TextMeshProUGUI dialogue;

    /// <summary>
    /// Called before the fir
    /// </summary>
    public void Awake()
    {
        dialogue = dialogueBox.GetComponent<TextMeshProUGUI>();
        mode = ActionScreenMode.Dialogue;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (mode.Equals(ActionScreenMode.Items))
            {
                SetMode(ActionScreenMode.Actions);
            }
        }
    }

    #region Setters
    public void SetMode(ActionScreenMode newMode)
    {
        if (newMode.Equals(ActionScreenMode.Dialogue))
        {
            actionButtons.SetActive(false);
            skillsButtons.SetActive(false);
            itemsButtons.SetActive(false);

            dialogueBox.SetActive(true);

            mode = ActionScreenMode.Dialogue;
        }
        else if (newMode.Equals(ActionScreenMode.Actions))
        {
            dialogueBox.SetActive(false);
            skillsButtons.SetActive(false);
            itemsButtons.SetActive(false);

            actionButtons.SetActive(true);

            mode = ActionScreenMode.Actions;

        }
        else if (newMode.Equals(ActionScreenMode.Skills))
        {
            dialogueBox.SetActive(false);
            actionButtons.SetActive(false);
            itemsButtons.SetActive(false);

            skillsButtons.SetActive(true);

            mode = ActionScreenMode.Skills;
        }
        else
        {
            dialogueBox.SetActive(false);
            actionButtons.SetActive(false);
            skillsButtons.SetActive(false);

            itemsButtons.SetActive(true);

            mode = ActionScreenMode.Items;
        }
    }

    
    public void SetDialogue(String newDialogue)
    {
        if (mode.Equals(ActionScreenMode.Dialogue) && dialogue != null)
        {
            this.dialogue.text = newDialogue;
        }
    }

    #endregion

}
