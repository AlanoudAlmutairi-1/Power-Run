using UnityEngine;

public class ExitController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameStateController gameStateController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (scoreManager.score >= 3)
            {
                gameStateController.PlayerWon();
            }
            else
            {
                Debug.Log("Exit is Locked!");
            }
        }
    }
}