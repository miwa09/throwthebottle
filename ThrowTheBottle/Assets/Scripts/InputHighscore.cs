using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHighscore : MonoBehaviour
{
    public string highscoreString;
    public int score;
    public string playerName;
    GameManager gm;
    public InputField nameInput;

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameManager>();
    }

    private void Update() {
        if (gm.ended) {
            if (!gm.chaos) {
                score = gm.GetComponent<NormalMode>().score;
            } else score = gm.GetComponent<ChaosMode>().score;
        }
    }

    public void SendHighscore() {
        if (playerName == null || playerName == "") {
            playerName = "???";
        }
        if (!gm.chaos) {
            GameObject.FindGameObjectWithTag("GameLogic").GetComponent<TestMenu>().SaveHighscore(score, playerName, highscoreString);
        } else GameObject.FindGameObjectWithTag("GameLogic").GetComponent<TestMenu>().SaveHighscore(score, playerName, highscoreString + "Chaos");

    }

    public void UpdateName() {
        playerName = nameInput.text;
    }
}
