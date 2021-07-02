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
    
    private void Awake() {
        ConfigureLevel();
    }

    private void Start() {
        inputManager = FindObjectOfType<InputManager>();
    }
    private void ConfigureLevel() {
        // set the level time and then initialize the timer
    }
    public void QuitGame() {
        Application.Quit();
    }

    public void StartGame() {
        Debug.Log("Starting game!");
    }

    public void LoadSceneByName(string sceneName) {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
