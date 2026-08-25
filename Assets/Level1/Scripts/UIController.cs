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
        scoreText.text = "Cells: " + scoreManager.score + "/3";
        timerText.text = "Time: " + Mathf.Round(timer.time);
        healthText.text = "Health: " + playerHealth.health;

        if (!gameStateController.startScreen.activeSelf)
        {
            scoreText.gameObject.SetActive(true);
            timerText.gameObject.SetActive(true);
            healthText.gameObject.SetActive(true);
        }
    }
}