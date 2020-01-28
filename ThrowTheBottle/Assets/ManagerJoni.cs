using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerJoni : MonoBehaviour
{
    public GameObject levelCompleteUI;
    public Text timerUI; //Get the UI element
    int seconds = 0; //Making the timer work like it's supposed to
    int minutes = 0;
    float clock;
    bool paused = false;

    void Update() {
        if (!paused) {
            Clock();
        }
    }

    void Clock() {
        clock += Time.deltaTime;
        while (clock >= 1f) {
            clock -= 1f;
            seconds++;
        }
        if (seconds >= 60) {
            seconds -= seconds;
            minutes++;
        }
        if (seconds < 10) {
            timerUI.text = "" + minutes + ":0" + seconds;
        }
        else timerUI.text = "" + minutes + ":" + seconds;
    }

    public void LevelComplete() {
        paused = true;
        levelCompleteUI.SetActive(true);
        //Debug.Log("voitit pelin");
    }
}
