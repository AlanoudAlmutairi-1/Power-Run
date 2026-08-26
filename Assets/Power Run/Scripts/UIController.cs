using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI healthText;

    public ScoreManager scoreManager;
    public Timer timer;
    public PlayerHealth playerHealth;

    public GameStateController gameStateController;

    void Start()
    {
        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        healthText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameStateController.startScreen.activeSelf)
        {
            return;
        }

        if (gameStateController.winScreen.activeSelf || gameStateController.lossScreen.activeSelf)
        {
            scoreText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            healthText.gameObject.SetActive(false);
            return;
        }

        scoreText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
        healthText.gameObject.SetActive(true);

        scoreText.text = "Cells: " + scoreManager.score + "/3";
        timerText.text = "Time: " + Mathf.Round(timer.time);
        healthText.text = "Health: " + playerHealth.health;
    }
}