using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 60f;
    public bool timerRunning = false;

    public GameStateController gameStateController;

    void Update()
    {
        if (timerRunning)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                time = 0;
                timerRunning = false;

                gameStateController.PlayerDied();
            }
        }
    }

    public void StartTimer()
    {
        timerRunning = true;
    }
}