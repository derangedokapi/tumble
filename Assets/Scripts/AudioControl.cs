using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    AudioSource myAudio;
    GameStatus gameStatus;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void PlaySound(AudioClip audioClip) {
        myAudio.volume = gameStatus.musicVolume;
        myAudio.clip = audioClip;
        myAudio.Play();
    }
}
