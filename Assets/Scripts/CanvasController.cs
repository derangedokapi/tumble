using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private void Start() {
        ActivateAllChildren();
    }
    public void DeactivateAllChildren(string exceptName) {
        Debug.Log("deacctivating except "+exceptName);
        foreach (Transform child in transform) {
            if (exceptName != child.gameObject.name) {
                Debug.Log("go "+child.gameObject);
                child.gameObject.SetActive(false);          
            }
            
        }
    }

    public void ActivateAllChildren() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
        }
    }
    
}
