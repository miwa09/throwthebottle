using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaosMode : MonoBehaviour
{
    public int score = 0;
    float scoreToApply;
    float timer;
    public float scoreUpdateTick = 0.01f;
    bool ended = false;
    public float distanceScoreMultiplier = 15f;
    public Text scoreUI;
    Vector3 spawnLocation;
    public Transform spawner;
    GameManager gm;
    List<ThrowableSensor> thrownObjects = new List<ThrowableSensor>();
    public int throws = 0;
    void Start()
    {
        gm = GetComponent<GameManager>();
        scoreUI.enabled = true;
        spawnLocation = spawner.position;
    }

    void Update()
    {
        if (scoreToApply > 0) {
            ApplyScore();
        }
        scoreUI.text = "" + score;
        if (ended) {
            CheckEnd();
        }
    }

    public void End() {
        gm.ended = true;
        ended = true;
        GameObject.FindGameObjectWithTag("spawner").GetComponent<BallSpawner>().enabled = false;
        GameObject.FindGameObjectWithTag("throwable").GetComponent<BetterThrow>().ended = true;
        ThrowableSensor[] thrownObjs = GameObject.FindObjectsOfType<ThrowableSensor>();
        foreach (ThrowableSensor obj in thrownObjs) {
            if (obj.isActiveAndEnabled) {
                thrownObjects.Add(obj);
            }
        }
    }

    void CheckEnd() {
        if (thrownObjects.Count > 0) {
            foreach (ThrowableSensor obj in thrownObjects) {
                if (!obj.isActiveAndEnabled) {
                    thrownObjects.Remove(obj);
                }
            }
        } else gm.Invoke("LevelComplete", 1f);
    }

    public void AddScore(float addscore) {
        scoreToApply += addscore;
    }

    public void AddScoreThrow(Vector3 hit) {
        float addscore = Vector3.Distance(hit, spawnLocation) * distanceScoreMultiplier;
        scoreToApply += addscore;
    }

    void ApplyScore() {
        if (scoreToApply > 0) {
            timer += Time.deltaTime;
            while (timer >= scoreUpdateTick) {
                timer -= scoreUpdateTick;
                if (scoreToApply - 5 < 0) {
                    score += Mathf.RoundToInt(scoreToApply);
                    scoreToApply = 0;
                } else {
                    score += 5;
                    scoreToApply -= 5;
                }
            }
        }
    }
}
