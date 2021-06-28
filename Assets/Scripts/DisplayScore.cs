using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{

    GameStatus gameStatus;
    TextMeshProUGUI scoreText;

    private void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        scoreText.text = gameStatus.GetCoinTotal().ToString();
    }
}
