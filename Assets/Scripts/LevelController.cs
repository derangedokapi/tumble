using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    public void QuitGame() {
        Application.Quit();
    }

    public void StartGame() {
        Debug.Log("Starting game!");
    }

    public void LoadSceneByName(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

}
