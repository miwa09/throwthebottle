using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleweedBackgroundScript : MonoBehaviour
{

    public GameObject tumbleweed;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject() {
        Instantiate(tumbleweed, transform.position, transform.rotation);
    }
}
