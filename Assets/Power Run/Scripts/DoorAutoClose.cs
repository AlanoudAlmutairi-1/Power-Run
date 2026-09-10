using UnityEngine;

public class DoorAutoClose : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioClip doorCloseSound;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetTrigger("CloseDoor");

            if (doorCloseSound != null)
            {
                AudioSource.PlayClipAtPoint(
                    doorCloseSound,
                    transform.position
                );
            }
        }
    }
}