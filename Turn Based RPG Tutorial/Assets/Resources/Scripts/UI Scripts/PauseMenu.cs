using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public KeyCode pauseButton;
    private bool isPaused;

    // Start is called before the first frame update
    public void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            { 
                Pause();
            }
        }
    }

    public void OnClickResume()
    {
        Resume();
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    private void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
}
