using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    private bool isPaused = false;

    public  bool GameIsPaused = false;

    public GameObject PauseScreenUI;
    void Update()
    {
        //TogglePause();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }
    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pauzemenu activeren

            // Cursor ontgrendelen en zichtbaar maken
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Pauzemenu deactiveren

            // Cursor vergrendelen en verbergen
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    
    public void Resume()
    {
        PauseScreenUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        GameIsPaused = true;
        PauseScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
