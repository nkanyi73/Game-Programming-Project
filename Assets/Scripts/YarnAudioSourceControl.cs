using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Yarn.Unity;

public class YarnAudioSourceControl : MonoBehaviour
{
    public VoiceOverView voiceOverView;

    public AudioSource player, narrator;

    public GameObject lever;

    public GameObject doorToMusicRoom;

    public void Start()
    {
        voiceOverView = FindAnyObjectByType<VoiceOverView>();
    }


    [YarnCommand("Set_Audio_To_Player")]
    public void SetAudioSourceToPlayer()
    {
        if(voiceOverView == null)
        {
            voiceOverView = FindAnyObjectByType<VoiceOverView>();
        }
        voiceOverView.audioSource = player;
        Debug.Log("Switching to player Audio Source");
    }

    [YarnCommand("Set_Audio_To_Narrator")]
    public void SetAudioSourceToNarrator()
    {
        if (voiceOverView == null)
        {
            voiceOverView = FindAnyObjectByType<VoiceOverView>();
        }
        voiceOverView.audioSource = narrator;
        Debug.Log("Switching to narrator Audio Source");

    }

    [YarnCommand("Deactivate_Axe_Collider")]
    public void DeactivateAxeCollider()
    {
        lever.transform.localPosition = new Vector3 (0.0176f, -0.213f, -0.0518f);
    }

    [YarnCommand("Open_Door_To_Music_Room")]
    public void OpenDoorToMusicRoom()
    {
        doorToMusicRoom.SetActive(false);
    }
}
