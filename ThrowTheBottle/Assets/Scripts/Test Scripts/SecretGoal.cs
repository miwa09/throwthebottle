using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Throwable")) {
            GameObject.FindGameObjectWithTag("GameLogic").GetComponent<NormalMode>().hitsToWin++;
            GameObject.FindGameObjectWithTag("unyielding").GetComponent<SecretEntity>().EntityTalk("do it... again.", 6f);
        }
    }
}
