using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
    private void Awake() {
        gameObject.SetActive(false);
    }
    public void ShowPanel() {
        gameObject.SetActive(true);
    }

    public void HidePanel() {
        gameObject.SetActive(false);
    }
}
