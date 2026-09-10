using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioSource collectSound;
    public ParticleSystem collectEffect;
    public Animator doorAnimator;
    public DroneController drone;
    public Door2Controller door2;

    public AudioClip doorOpenSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore();

            // Door 2
            if (door2 != null)
            {
                door2.canOpen = true;
            }
            else
            {
                // Door 1 or Door 3
                if (doorAnimator != null)
                {
                    doorAnimator.SetTrigger("OpenDoor");

                    if (doorOpenSound != null)
                    {
                        AudioSource.PlayClipAtPoint(
                            doorOpenSound,
                            transform.position
                        );
                    }
                }
            }

            // Start Drone
            if (drone != null)
            {
                drone.isChasing = true;
            }

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