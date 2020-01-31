using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour, ISpawner
{
    public GameObject prefab;

    public void Spawn() {
        if (GameObject.FindGameObjectsWithTag("throwable").Length < 1) {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
