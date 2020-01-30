using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour, ISpawner
{
    public GameObject prefab;

    public void Spawn() {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
