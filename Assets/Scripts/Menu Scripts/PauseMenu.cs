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
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelChanger.isChangingScene)
            return;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (gameIsPaused)
            {
                OnResumeButton();
            }
            else
            {
                OnPauseButton();
            }
        }
    }

    public void OnResumeButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        gameplayUI.SetActive(true);
        Resume();
    }

    public void OnPauseButton()
    {
        Cursor.lockState = CursorLockMode.Confined;
        gameplayUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Pause();
    }

    public void Resume()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void Pause()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        PauseMenu.gameIsPaused = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
        gameplayUI.SetActive(false);
        endGameMenuUI.SetActive(true);
    }

    public void MainMenu()
    {
        levelChanger.FadeToLevel(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ReloadScene()
    {
        levelChanger.FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
