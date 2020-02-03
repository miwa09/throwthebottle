using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalMode : MonoBehaviour
{
    GameManager gm;
    public int misses = 0;
    int hits = 0;
    public int hitsToWin = 5;
    public float[] scoreMultipliers;
    int multiplierIndex = 0;
    public int score = 0;
    public int scorePerHit = 1000;
    bool perfect = false;
    public Text scoreUI;
    public Text multiplierUI;
    public float scoreUpdateTick= 0.01f;
    float timer = 0;
    public int scoreToApply;
    int failsafe = 1;
    public Image[] failsafeUI;
    [Tooltip("Par time for the stage in seconds")]
    public int parTime;
    public float parTimeScore = 1000;
    float scoreTime;
    bool doOnce = true;

    private void Start() {
        gm = GetComponent<GameManager>();
        scoreUI.enabled = true;
        multiplierUI.enabled = true;
        foreach (Image obj in failsafeUI) {
            obj.gameObject.SetActive(true);
        }
    }

    private void Update() {
        ApplyScore();
        FailsafeUIUpdate();
        scoreUI.text = "" + score;
        multiplierUI.text = "" + scoreMultipliers[multiplierIndex] + "x";
        if (hits >= hitsToWin) {
            End();
        }
    }

    public void End() {
        if (doOnce) {
            if (misses == 0) {
                perfect = true;
            }
            float parTimeF = parTime; //turning already exisisting integer values to floats to make the calculations below work and as to not lose my mind
            float minutesF = gm.minutes;
            float secondsF = gm.seconds;
            scoreTime = parTimeF / (minutesF * 60 + secondsF) * parTimeScore;
            scoreTime = Mathf.Clamp(scoreTime, parTimeScore / 2, parTimeScore * 2);
            if (scoreTime <= parTimeScore / 2) {
                scoreTime = 0;
            }
            gm.Invoke("LevelComplete", 0.5f);
            if (scoreToApply > 0) {
                score += scoreToApply;
                scoreToApply = 0;
            }
            Invoke("AddTimeScore", 1);
            doOnce = false;
        }
    }

    public void Score() {
        scoreToApply += Mathf.RoundToInt(scorePerHit * scoreMultipliers[multiplierIndex]);
        hits++;
    }

    public void AddScore(int addscore) {
        scoreToApply += addscore;
    }

    void AddTimeScore() {
        scoreToApply = 0;
        scoreToApply += Mathf.RoundToInt(scoreTime);
        doOnce = false;
    }

    void ApplyScore() {
        if (scoreToApply > 0) {
            timer += Time.deltaTime;
            while (timer >= scoreUpdateTick) {
                timer -= scoreUpdateTick;
                if (scoreToApply - 5 < 0) {
                    score += scoreToApply;
                    scoreToApply = 0;
                } else {
                    score += 5;
                    scoreToApply -= 5;
                }
            }
        }
    }

    public void Miss() {
        misses++;
        failsafe--;
        if (failsafe <= 0) {
            failsafe = 3;
            if (multiplierIndex < scoreMultipliers.Length) {
                multiplierIndex++;
            }
        }
    }

    void FailsafeUIUpdate() {
        if (failsafe == 1) {
            failsafeUI[0].enabled = true;
            failsafeUI[1].enabled = true;
            return;
        }
        if (failsafe == 2) {
            failsafeUI[0].enabled = true;
            failsafeUI[1].enabled = false;
            return;
        }
        if (failsafe == 3) {
            failsafeUI[0].enabled = false;
            failsafeUI[1].enabled = false;
            return;
        }
    }
}
