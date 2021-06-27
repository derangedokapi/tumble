using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = "Use the left and right arrows to move";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
