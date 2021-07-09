using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStatsSummary : MonoBehaviour
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
        scoreSummary.text = "Last score: "+gameStatus.lastCoins+"\nHigh score: "+gameStatus.highCoins;
    
    }
}
