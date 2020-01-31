using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    GameManager manager;
    private void Start() {
        manager = FindObjectOfType<GameManager>();
        if (manager.chaos) {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Throwable")) {
            GameObject.FindGameObjectWithTag("GameLogic").GetComponent<NormalMode>().Score();
            other.GetComponent<ThrowableSensor>().enabled = false;
        }
    }
}
