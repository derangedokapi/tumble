using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    AudioSource myAudio;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip) {
        myAudio.clip = audioClip;
        myAudio.Play();
    }
}
