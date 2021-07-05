using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] PanelControl escapePanel;
    [SerializeField] PanelControl levelPanel;

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
}
