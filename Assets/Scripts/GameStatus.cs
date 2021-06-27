using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public float fallSpeed = 15f;

    [SerializeField] float coins;

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

    private void SetUpSingleton() {
        if (FindObjectsOfType(GetType()).Length > 1) {
            gameObject.SetActive(false); // this is due to a bug addressed in bug lesson
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
