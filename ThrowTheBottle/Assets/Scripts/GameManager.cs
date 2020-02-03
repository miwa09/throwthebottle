using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject levelCompleteUI;
    public Text timerUI; //Get the UI element
    public int seconds = 0; //Making the timer work like it's supposed to
    public int minutes = 0;
    float clock;
    float timer;
    public float chaosTimelimit = 60f;
    bool paused = false;
    float lastTimescale = 1;
    public bool chaos = false;
    public bool ended = false;
    public Text score;
    public Text timeTaken;
    public Text misses;
    public GameObject inGameCanvas;
    public GameObject menu;
    NormalMode nm;
    ChaosMode cm;

    private void Awake() {
        if (GameObject.FindGameObjectWithTag("PData").GetComponent<ModeSelector>().chaos){
            chaos = true;
        }
    }

    private void Start() {
        nm = GetComponent<NormalMode>();
        cm = GetComponent<ChaosMode>();
        if (!chaos) {
            cm.enabled = false;
            nm.enabled = true;
        } else {
            cm.enabled = true;
            nm.enabled = false;
        }
    }

    void Update() {
        if (!chaos && !ended) {
            Clock();
        }
        if (chaos && !ended) {
            Timer();
        }
        if (ended) {
            if (!chaos) {
                if (nm.scoreToApply > 0) {
                    score.text = "" + nm.score + " + " + nm.scoreToApply;
                } else score.text = "" + nm.score;
                misses.text = "Misses: " + nm.misses;
                if (seconds < 10) {
                    timeTaken.text = "Time: " + minutes + ":0" + seconds;
                } else timeTaken.text = "Time: " + minutes + ":" + seconds;
            } else {
                score.text = "" + cm.score;
                misses.text = "Thrown: " + cm.throws;
                timeTaken.text = "";
            }
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

    void Timer() {
        timer += Time.deltaTime;
        while (timer >= 1f) {
            timer -= 1f;
            chaosTimelimit--;
        }
        if (chaosTimelimit <= 0) {
            cm.End();
        }
        timerUI.text = "" + chaosTimelimit;
    }

    public void LevelComplete() {
        ended = true;
        CompletePause();
        levelCompleteUI.SetActive(true);
        inGameCanvas.SetActive(false);
        menu.SetActive(false);
    }


    public void Pause() {
        lastTimescale = Time.timeScale;
        Time.timeScale = 0;
    }

    void CompletePause() {
        Rigidbody[] rigs = GameObject.FindObjectsOfType<Rigidbody>();
        GameObject.FindGameObjectWithTag("throwable").GetComponent<BetterThrow>().ended = true;
        GameObject.FindGameObjectWithTag("spawner").GetComponent<BallSpawner>().enabled = false;
        foreach (Rigidbody rig in rigs) {
            rig.velocity = Vector3.zero;
            rig.isKinematic = true;
            rig.useGravity = false;
        }
    }

    public void Resume() {
        Time.timeScale = lastTimescale;
    }
}
