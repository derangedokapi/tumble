using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private void Start() {
        ActivateAllChildren();
    }
    public void DeactivateAllChildren() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }

    public void ActivateAllChildren() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
        }
    }
    
}
