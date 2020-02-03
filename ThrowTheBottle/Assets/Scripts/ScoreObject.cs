using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour, IDestroyable
{
    bool chaos = false;
    public int score = 100;
    GameManager gm;
    public bool destroyThrowable = false;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameManager>();
    }

    public void DestroyObj() {
        if (!chaos) {
            gm.GetComponent<NormalMode>().AddScore(score);
        } else gm.GetComponent<ChaosMode>().AddScore(score);
        Destroy(gameObject);
    }
}
