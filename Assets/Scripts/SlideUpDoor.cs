using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideUpDoor : MonoBehaviour
{
    public Animator animator;
    public GameObject canvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lever"))
        {
            animator.Play("SlideUpDoor");
            canvas.SetActive(true);
        }
    }

}
