using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{


    public float coins;
    public float lastCoins = 0;
    public float highCoins = 0;

    Slider healthSlider;

    public float playerHealth = 100f;
    float originalHealth;

    [Header("Sound")]
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
    [SerializeField] AudioSource musicSource;

    [Header("Levels")]
    public LevelConfigSO[] levelConfigOptions;
    
    public int currentLevel;

    InputManager inputManager;

    private void Awake() {
        SetUpSingleton();
    }

    private void Start() {
        originalHealth = playerHealth;
        inputManager = FindObjectOfType<InputManager>();
        RestartGame();
    }

    public void RestartGame() {
        if (coins > highCoins) { 
            highCoins = coins;
        }
        lastCoins = coins;
        coins = 0;
        currentLevel = 0;
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
        if (playerHealth <= 0){
            FindObjectOfType<InputManager>().LoadGameOverPanel();
        }
    }

}
