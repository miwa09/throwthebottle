using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDataScore : MonoBehaviour {

    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("PData");
        if (objs.Length > 1) {
            for(int i = 0; i < objs.Length - 1; i++) {
                Destroy(objs[i + 1]);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

}
