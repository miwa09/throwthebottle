using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDataScore : MonoBehaviour
{
    List<Score> scoresNormal = new List<Score>();
    List<Score> scoresChaos = new List<Score>();
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("PData");
        if (objs.Length > 1) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public void AddScore(Score score, int modeindex) {
        if (modeindex == 0) {
            if (scoresNormal.Count > 0) {

            }
            scoresNormal.Add(score);
            return;
        }
        if (modeindex == 1) {
            scoresChaos.Add(score);
            return;
        }
    }
}

public struct Score {
    public int score;
    public string name;

    public Score(int s, string n) {
        score = s;
        name = n;
    }
}
