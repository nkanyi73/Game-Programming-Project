using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverAnimationControl : MonoBehaviour
{
    public Animator [] axeAnimator;
    public Collider [] axeCollider;
    public GameObject[] axePrefab;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        for (int i = 0; i < axeAnimator.Length; i++)
        {
            axeAnimator[i].SetBool("isActive", false);
            axeCollider[i].enabled = false;
            axePrefab[i].transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 60f));
        }
        
    }
}
