using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverAnimationControl : MonoBehaviour
{
    public Animator axeAnimator;
    public Collider axeCollider;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        axeAnimator.SetBool("isActive", false);
        axeCollider.enabled = false;
        //StartCoroutine();
    }

    //IEnumerator RevertToMainCamera()
    //{
    //    yield return new WaitForSeconds(5);
    //    mainCamera.enabled = true;
    //    doorCamera.enabled = false;

    //}

    //void StartCoroutine()
    //{
    //    RevertToMainCamera();
    //}
}
