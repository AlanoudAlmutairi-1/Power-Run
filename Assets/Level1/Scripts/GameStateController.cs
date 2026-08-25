using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameStateController : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject pauseScreen;
    public GameObject lossScreen;
    public GameObject winScreen;

    public Timer timer;

    void Start()
    {
        Time.timeScale = 1f;

        startScreen.SetActive(true);
        pauseScreen.SetActive(false);
        lossScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (Time.timeScale == 1f)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        timer.StartTimer();
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PlayerDied()
    {
        lossScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayerWon()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}