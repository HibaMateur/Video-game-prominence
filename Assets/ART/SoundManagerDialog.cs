using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerDialog : MonoBehaviour
{
   public static SoundManagerDialog instance { get; private set; }

    private AudioSource audiosc;

    private void Awake()
    {
        instance = this;
        audiosc = GetComponent<AudioSource>();

    }
    public void PlaySound(AudioClip sound)
    {
        audiosc.PlayOneShot(sound);
    }
}
