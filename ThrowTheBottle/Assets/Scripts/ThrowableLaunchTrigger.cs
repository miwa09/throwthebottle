using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableLaunchTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("throwable")) {
            other.GetComponent<BetterThrow>().LeaveSpawn();
        }
    }
}
