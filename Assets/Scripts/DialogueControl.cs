using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueControl : MonoBehaviour
{
    [SerializeField] float secondsPerMessage = 3f;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] string[] introductionText;
    
    [SerializeField] string[] randomThoughts;

    int introductionIndex = 0;

    private void Start() {
        PopulateWords(introductionText[introductionIndex]);
        StartCoroutine("PlayInstructions");
    }

    IEnumerator PlayInstructions() {
        while (true) {
            yield return new WaitForSeconds(secondsPerMessage);
            if (introductionIndex < introductionText.Length) {
                PopulateWords(introductionText[introductionIndex]);
                introductionIndex++;
            } else {
                ChooseRandomDialogue();
            }
        }
        
       
    }

    private void ChooseRandomDialogue() {
        PopulateWords(ReturnRandomFromList(randomThoughts));
    }

    public void PopulateWords(string str) {
        dialogueText.text = str;        
    }

    private string ReturnRandomFromList(string[] list) {
        var index = Random.Range(0, list.Length);
        return (list[index]);
    }
}
