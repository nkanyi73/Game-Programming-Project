using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMusicRoom : MonoBehaviour
{
    public Animator rightDoorAnimator;
    public Animator leftDoorAnimator;
    public AudioSource doorSlide;
    public bool hasBeenTriggered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasBeenTriggered)
            {
                Debug.Log("Collision Detected");
                rightDoorAnimator.Play("RightDoorClose");
                leftDoorAnimator.Play("LeftDoorClose");
                doorSlide.Play();
                hasBeenTriggered = true;
            }
        }
    }
}
