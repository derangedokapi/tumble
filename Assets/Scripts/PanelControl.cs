using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelControl : MonoBehaviour
{
    CanvasGroup thisCanvas;
    private void Awake() {
        thisCanvas = GetComponent<CanvasGroup>();
        HidePanel();
    }

    public void TogglePanel() {
        bool panelIsShowing = thisCanvas.interactable;
        if (panelIsShowing) {
            HidePanel();
        } else {
            ShowPanel();
        }

    }
    public void ShowPanel() {
        thisCanvas.alpha = 1;
        thisCanvas.interactable = true;
        Time.timeScale = 0;
    }

    public void HidePanel() {
        Time.timeScale = 1;
        thisCanvas.alpha = 0;
        thisCanvas.interactable = false;
    }
}
