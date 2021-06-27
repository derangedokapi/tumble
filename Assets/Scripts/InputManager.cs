using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] PanelControl escapePanel;
    private void Update() {
        if (Input.GetButtonDown("Cancel")) {
            Debug.Log("esc!");
            escapePanel.ShowPanel();
        }
    }
}
