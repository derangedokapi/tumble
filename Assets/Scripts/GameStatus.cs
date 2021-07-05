using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    public float fallSpeed = 15f;

    [SerializeField] float coins;
    float lastCoins = 0;
    float highCoins = 0;

    Slider healthSlider;

    public float playerHealth = 100f;
    float originalHealth;

    [Header("Sound")]
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
    [SerializeField] AudioSource musicSource;

    [Header("Levels")]
    public LevelConfigSO[] levelConfigOptions;
    
    public int currentLevel = 0;

    private void Awake() {
        SetUpSingleton();
    }

    private void Start() {
        originalHealth = playerHealth;
        RestartGame();
    }

    public void RestartGame() {
        lastCoins = coins;
        if (coins > highCoins) { 
            highCoins = coins;
        }
        coins = 0;
        playerHealth = originalHealth;
    }

    public void ChangeCoins (float amountToChange) {
        float newAmount = coins + amountToChange;
        coins = Mathf.Clamp(newAmount, 0, 1000000);
    }

    public float GetCoinTotal() {
        return coins;
    }

    private void SetUpSingleton() {
        if (FindObjectsOfType(GetType()).Length > 1) {
            gameObject.SetActive(false); // this is due to a bug addressed in bug lesson
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ChangeMusicVolume(float newVolume) {
        musicSource.volume = newVolume;
        musicVolume = newVolume;
    }

    public void PlayerTakeDamage(float damageAmount) {
        playerHealth -= damageAmount;
    }


}
