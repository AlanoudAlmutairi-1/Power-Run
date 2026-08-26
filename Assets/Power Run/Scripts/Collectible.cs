using UnityEngine;

public class Collectible : MonoBehaviour
{
    public ScoreManager scoreManager;
    public AudioSource collectSound;
    public ParticleSystem collectEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreManager.AddScore();

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    collectSound.clip,
                    transform.position
                );
            }

            if (collectEffect != null)
            {
                Instantiate(
                    collectEffect,
                    transform.position,
                    Quaternion.identity
                );
            }

            Destroy(gameObject);
        }
    }
}