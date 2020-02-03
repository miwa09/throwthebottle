using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    GameObject[] prefabs;
    float timer;
    float randomTicker;
    float randomTimerMin = 4f;
    float randomTimerMax = 15f;

    private void Start() {
        randomTicker = Random.Range(randomTimerMin, randomTimerMax);
    }

    private void Update() {
        timer += Time.deltaTime;
    }
}
