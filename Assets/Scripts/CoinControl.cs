using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    [SerializeField] float speedFactor = 1.3f;
    [SerializeField] float coinValue = 0;
    float moveSpeed;

    [SerializeField] AudioClip pickupAudioClip;
    AudioControl gameAudio;

    GameStatus gameStatus;
    LevelConfigSO levelConfig;
    private void Start() {
        gameAudio = FindObjectOfType<AudioControl>();
        gameStatus = FindObjectOfType<GameStatus>();
        levelConfig = FindObjectOfType<LevelController>().gameLevelObject;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = levelConfig.fallSpeed * speedFactor;
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
    }

    public float GetCoinValue() {
        return coinValue;
    }

    public void PickupCoin() {
        gameAudio.PlaySound(pickupAudioClip);
        gameStatus.ChangeCoins(coinValue);
        Destroy(gameObject);
    }
}
