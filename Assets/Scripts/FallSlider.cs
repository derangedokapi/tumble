using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallSlider : MonoBehaviour
{

    float levelTime = 30f;
    bool timerFinished = false;

    LevelController levelController;
    
    void Start() {
        //levelTime = FindObjectOfType<LevelController>().GetLevelDuration();
        levelController = FindObjectOfType<LevelController>();
    }
    void Update()
    {
        if (timerFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        timerFinished = Time.timeSinceLevelLoad >= levelTime;
        if (timerFinished) {
            levelController.EndLevel();

        }
    }

    public void SetSliderTime(int timeValue) {
        GetComponent<Slider>().value = timeValue;
    }
}

