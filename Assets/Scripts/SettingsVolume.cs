using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsVolume : MonoBehaviour
{
    GameStatus gameStatus;
    Slider musicSlider;

    private void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
        musicSlider = GetComponent<Slider>();
        musicSlider.value = gameStatus.musicVolume;
    }

    public void ChangeMusicVolume(){ 
        gameStatus.ChangeMusicVolume(musicSlider.value);
    }
}
