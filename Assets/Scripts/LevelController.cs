using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject cloudSpawnerParent;
    [SerializeField] Player player;
    [SerializeField] GroundControl ground;

    InputManager inputManager;
    GameStatus gameStatus;

    public LevelConfigSO gameLevelObject;
    
    private void Awake() {
        inputManager = FindObjectOfType<InputManager>();
        gameStatus = FindObjectOfType<GameStatus>();
        ConfigureLevel();
    }

   
    private void ConfigureLevel() {
        
     
        gameLevelObject = gameStatus.levelConfigOptions[gameStatus.currentLevel];
        Debug.Log("current level = "+gameStatus.currentLevel+" obj = "+gameLevelObject);
        foreach (Transform child in cloudSpawnerParent.transform) {
            child.GetComponent<CloudSpawner>().clouds = gameLevelObject.availableEnemies;
        }
        // set the level time and then initialize the timer
    }
    public void QuitGame() {
        Application.Quit();
    }

    public void StartGame() {
        Debug.Log("Starting game!");
    }

    public void LoadSceneByName(string sceneName) {
        Debug.Log("Loading scene "+sceneName);     
        switch (sceneName) {
            case "Main Menu":
                gameStatus.RestartGame();
                break;
        }  
        SceneManager.LoadScene(sceneName);
        
    }

    public void EndLevel() {
        foreach (Transform child in cloudSpawnerParent.transform) {
            child.GetComponent<CloudSpawner>().StopSpawning();
        }
        ground.Rise();
    }

    public void PlayerToGround() {
        player.FallToGround();
    }

    public void LoadNextLevel() {
        Debug.Log("load next level");
        gameStatus.currentLevel++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowEndLevelOptions() {

    }

}
