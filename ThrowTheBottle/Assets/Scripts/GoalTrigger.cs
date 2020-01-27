using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    ManagerJoni manager;
    private void Start() {
        manager = FindObjectOfType<ManagerJoni>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "throwable") {
            manager.Invoke("LevelComplete", 1);
        }
    }
}
