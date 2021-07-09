using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelControl : MonoBehaviour
{
    // for the pause menu via escape button, used by InputManager
    // for the game over module, called by GameStatus
    [SerializeField] CanvasGroup thisCanvas;
    [SerializeField] CanvasController canvasControl;
    private void Start() {
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
        /*
        if (thisCanvas == null) {
            Debug.Log("failed - trying to show panel "+thisCanvas);
            
            canvasControl = FindObjectOfType<CanvasController>();
            Debug.Log("retry - trying to show panel "+thisCanvas);
        }
        */
        thisCanvas = GetComponent<CanvasGroup>();
        Time.timeScale = 0;
        FindObjectOfType<CanvasController>().DeactivateAllChildren(gameObject.name);
        thisCanvas.gameObject.SetActive(true);
        thisCanvas.alpha = 1;
        thisCanvas.interactable = true;
        Debug.Log(thisCanvas+" alpha = "+thisCanvas.alpha+" int "+thisCanvas.interactable);
       
    }

    public void HidePanel() {
        Time.timeScale = 1;
        thisCanvas.alpha = 0.0001f;
        canvasControl.ActivateAllChildren();
        thisCanvas.interactable = false;
        thisCanvas.gameObject.SetActive(false);
    }
}
