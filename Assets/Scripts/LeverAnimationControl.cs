using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverAnimationControl : MonoBehaviour
{
    public Animator [] axeAnimator;
    public Collider [] axeCollider;
    public GameObject[] axePrefab;
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioSource audioSource2;
    public AudioClip clip2;
    private bool playAudioClip = true;

    private void Start()
    {
        StartCoroutine(PlayAudioLoop());
        StartCoroutine(PlayHingeAudioLoop());
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        for (int i = 0; i < axeAnimator.Length; i++)
        {
            axeAnimator[i].SetBool("isActive", false);
            axeCollider[i].enabled = false;
            axePrefab[i].transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 60f));
            playAudioClip = false;
        }
        
    }

    IEnumerator PlayAudioLoop()
    {
        while (playAudioClip)
        {
            yield return new WaitForSeconds(2.0f);

            // Play the audio clip
            audioSource.PlayOneShot(clip);
        }
    }

    IEnumerator PlayHingeAudioLoop()
    {
        while (playAudioClip)
        {
            yield return new WaitForSeconds(3.0f);

            // Play the audio clip
            audioSource2.PlayOneShot(clip2);
        }
    }
}
