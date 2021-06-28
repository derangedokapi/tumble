using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{

    Slider healthSlider;
    GameStatus gameStatus;
    private void Start() {
        healthSlider = GetComponent<Slider>();
        gameStatus = FindObjectOfType<GameStatus>();
    }
    private void Update() {
        healthSlider.value = gameStatus.playerHealth;
    }
}
