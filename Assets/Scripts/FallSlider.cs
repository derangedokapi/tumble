using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallSlider : MonoBehaviour
{

    [SerializeField] float fallThreshold = 0.95f;
     [SerializeField] float levelTime = 30f;
    bool timerFinished = false;
    

    LevelController levelController;
    
    void Start() {

        levelController = FindObjectOfType<LevelController>();
                levelTime = levelController.gameLevelObject.levelDuration;
        Debug.Log("setting level time to "+levelTime);
    }
    
    void Update()
    {
        if (timerFinished) { return; }
        var percLeft = Time.timeSinceLevelLoad / levelTime;
        GetComponent<Slider>().value = percLeft;
        //timerFinished = Time.timeSinceLevelLoad >= levelTime;
        if (percLeft >= fallThreshold) {
            timerFinished = true;
            levelController.EndLevel();
        }
    }

    public void SetSliderTime(int timeValue) {
        GetComponent<Slider>().value = timeValue;
    }
}

