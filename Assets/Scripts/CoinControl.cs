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
    private void Start() {
        gameAudio = FindObjectOfType<AudioControl>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = gameStatus.fallSpeed * speedFactor;
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
    }

    public float GetCoinValue() {
        return coinValue;
    }

    public void PickupCoin() {
        Debug.Log("PICKUP" + gameObject);
        gameAudio.PlaySound(pickupAudioClip);
        gameStatus.ChangeCoins(coinValue);
        Destroy(gameObject);
    }
}
