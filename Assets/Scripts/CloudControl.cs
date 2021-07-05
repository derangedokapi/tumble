using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour
{
    [SerializeField] float speedFactor = 1.3f;
    [SerializeField] float coinValue = 0;
    float moveSpeed;
    bool moving = true;

    

    //GameStatus gameStatus;
    LevelConfigSO levelConfig;
    private void Start() {
        //gameStatus = FindObjectOfType<GameStatus>();
        levelConfig = FindObjectOfType<LevelController>().gameLevelObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving) return;
        moveSpeed = levelConfig.fallSpeed * speedFactor;
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
    }

    public float GetCoinValue() {
        return coinValue;
    }

    public void StopMoving() {
        moving = false;
    }
}
