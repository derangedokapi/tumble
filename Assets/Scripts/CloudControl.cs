using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour
{

    float moveSpeed;

    GameStatus gameStatus;
    private void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = gameStatus.fallSpeed;
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
    }
}
