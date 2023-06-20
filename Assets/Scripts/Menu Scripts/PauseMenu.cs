using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    [SerializeField] GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameIsPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        gameIsPaused = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
    }

    public void MainMenu()
    {
        Resume();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
