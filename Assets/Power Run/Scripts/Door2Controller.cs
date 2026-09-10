using UnityEngine;

public class Door2Controller : MonoBehaviour
{
    public Animator doorAnimator;
    public bool canOpen = false;

    public AudioClip doorOpenSound;

    private bool hasOpened = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canOpen && !hasOpened)
        {
            doorAnimator.SetTrigger("OpenDoor");
            hasOpened = true;

            if (doorOpenSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    doorOpenSound,
                    transform.position
                );
            }
        }
    }
}