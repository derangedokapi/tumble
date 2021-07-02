using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject cloudSpawnerParent;
    [SerializeField] Player player;
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
        player.FallToGround();
    }

}
