using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReseter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("throwable")) {
            other.GetComponent<TestThrow>().ResetBall();
        }
    }
}
