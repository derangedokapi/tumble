using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelControl : MonoBehaviour
{
    // for the pause menu via escape button, used by InputManager
    // for the game over module, called by GameStatus
    CanvasGroup thisCanvas;
    CanvasController canvasControl;
    private void Awake() {
        thisCanvas = GetComponent<CanvasGroup>();
        canvasControl = FindObjectOfType<CanvasController>();
        HidePanel();
    }

   

    public void TogglePanel() {
        bool panelIsShowing = thisCanvas.alpha == 1;
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
    canvasControl.DeactivateAllChildren();
    thisCanvas.gameObject.SetActive(true);
    }

    public void HidePanel() {
        Time.timeScale = 1;
        thisCanvas.alpha = 0;
        canvasControl.ActivateAllChildren();
        //thisCanvas.interactable = false;
    }

    public void EndLevel() {
        
    }
}
