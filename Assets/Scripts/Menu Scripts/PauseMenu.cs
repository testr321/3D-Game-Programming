using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    [SerializeField] GameObject gameplayUI;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject endGameMenuUI;

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(gameIsPaused);
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
        gameplayUI.SetActive(true);
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        gameIsPaused = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
        gameplayUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void EndGame()
    {
        PauseMenu.gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        AudioListener.pause = true;
        gameplayUI.SetActive(false);
        endGameMenuUI.SetActive(true);
    }

    public void MainMenu()
    {
        Resume();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ReloadScene()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
