using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIGameOverText : MonoBehaviour
{
    GameStatus gameStatus;
    TextMeshProUGUI scoreSummary;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        scoreSummary = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreSummary.text = "Game Over!"+"\nYour score: "+gameStatus.coins;
    
    }
}
