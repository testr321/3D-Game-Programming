using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    
    [SerializeField] GameObject gameplayUI;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject endGameMenuUI;

    LevelChanger levelChanger;

    void Awake()
    {
        levelChanger = FindObjectOfType<LevelChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelChanger.isChangingScene)
            return;

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
        gameplayUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        levelChanger.FadeToLevel(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ReloadScene()
    {
        Resume();
        gameplayUI.SetActive(false);
        levelChanger.FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
