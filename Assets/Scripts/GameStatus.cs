using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    public float fallSpeed = 15f;

    [SerializeField] float coins;

    Slider healthSlider;

    public float playerHealth = 100f;

    [Header("Sound")]
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
    [SerializeField] AudioSource musicSource;

    private void Awake() {
        SetUpSingleton();
    }

    private void Start() {
        
        RestartGame();
    }

    public void RestartGame() {
        coins = 0;
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
