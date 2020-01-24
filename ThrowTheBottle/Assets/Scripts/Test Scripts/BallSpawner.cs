using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject prefab;

    public void SpawnBall() {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
