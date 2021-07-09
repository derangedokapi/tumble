using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] PanelControl escapePanel;
    [SerializeField] PanelControl levelPanel;

    [SerializeField] PanelControl gameOverPanel;

    bool levelOver = false;
    private void Update() {
        if (!levelOver && Input.GetButtonDown("Cancel")) {
            escapePanel.TogglePanel();
            levelPanel.HidePanel();
        }
    }

    public void LoadLevelPanel() {
        levelOver = true;
        levelPanel.ShowPanel();
    }

    public void LoadGameOverPanel() {
        Debug.Log("called game over panel "+gameOverPanel);
        levelOver = true;
        gameOverPanel.ShowPanel();
    }
}
