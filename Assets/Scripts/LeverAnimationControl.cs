using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverAnimationControl : MonoBehaviour
{
    public Animator doorAnimator;
    public Camera mainCamera;
    public Camera doorCamera;
    private void OnTriggerEnter(Collider other)
    {
        doorCamera.enabled = true;
        mainCamera.enabled = false;
        doorAnimator.SetBool("isOpen", true);
        StartCoroutine();
    }

    IEnumerator RevertToMainCamera()
    {
        yield return new WaitForSeconds(5);
        mainCamera.enabled = true;
        doorCamera.enabled = false;

    }

    void StartCoroutine()
    {
        RevertToMainCamera();
    }
}
