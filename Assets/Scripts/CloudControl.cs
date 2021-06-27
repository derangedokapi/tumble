using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour
{
    [SerializeField] float speedFactor = 1.3f;
    float moveSpeed;

    GameStatus gameStatus;
    private void Start() {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = gameStatus.fallSpeed * speedFactor;
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
    }
}
