using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMode : MonoBehaviour
{
    public float parTime; //in seconds
    int misses = 0;
    int hits = 0;
    public int hitsToWin = 5;
    float scoreMultiplier = 2;
    public int score = 0;
    public int scorePerHit = 1000;
    bool perfect = false;

    private void Update() {
        if (hits >= hitsToWin) {
            End();
        }
    }

    void End() {
        if (misses == 0) {
            perfect = true;
        }
        GetComponent<GameManager>().Invoke("LevelComplete", 0.5f);
    }

    public void Score() {
        score += Mathf.RoundToInt(scorePerHit * scoreMultiplier);
        hits++;
    }

    public void AddScore(int addscore) {
        score += addscore;
    }

    public void Miss() {
        misses++;
        if (misses == 1) {
            scoreMultiplier = 1.5f;
        }
        if (misses == 2) {
            scoreMultiplier = 1.3f;
        }
        if (misses == 3) {
            scoreMultiplier = 1.2f;
        }
        if (misses == 4) {
            scoreMultiplier = 1.1f;
        }
        if (misses == 5) {
            scoreMultiplier = 1f;
        }
        if (misses == 6) {
            scoreMultiplier = 0.9f;
        }
        if (misses == 7) {
            scoreMultiplier = 0.8f;
        }
        if (misses == 8) {
            scoreMultiplier = 0.7f;
        }
        if (misses == 9) {
            scoreMultiplier = 0.6f;
        }
        if (misses >= 10) {
            scoreMultiplier = 0.5f;
        }
    }
}
