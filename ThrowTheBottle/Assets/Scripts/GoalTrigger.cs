using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    GameManager manager;
    private void Start() {
        manager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "throwable") {
            manager.Invoke("LevelComplete", 0.5f);
        }
    }
}
