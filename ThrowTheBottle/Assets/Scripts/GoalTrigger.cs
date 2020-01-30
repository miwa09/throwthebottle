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
        if (other.gameObject.tag == "throwable") { //Voit myös käyttää other.CompareTag("throwable"), tekee saman asian hieman siistimmin
            GameObject.FindGameObjectWithTag("GameLogic").GetComponent<NormalMode>().Score();
            other.GetComponent<ThrowableSensor>().enabled = false;
        }
    }
}
