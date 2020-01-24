using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReseter : MonoBehaviour
{
    public BallSpawner spawn;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("throwable")) {
            Destroy(other.gameObject);
            spawn.SpawnBall();
        }
    }
}
