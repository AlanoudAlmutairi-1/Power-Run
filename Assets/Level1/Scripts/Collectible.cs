using UnityEngine;

public class Collectible : MonoBehaviour
{
    public ScoreManager scoreManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreManager.AddScore();
            Destroy(gameObject);
        }
    }
}