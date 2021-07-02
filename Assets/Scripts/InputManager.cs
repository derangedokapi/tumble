using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] PanelControl escapePanel;
    [SerializeField] PanelControl levelPanel;
    private void Update() {
        if (Input.GetButtonDown("Cancel")) {
            escapePanel.TogglePanel();
            levelPanel.HidePanel();
        }
    }

    public void LoadLevelPanel() {
        levelPanel.ShowPanel();
    }
}
