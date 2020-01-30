using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrigger : MonoBehaviour
{
    public GameObject explosion;
    public float explosionTime = 0.5f;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "throwable") {
            SetExplosionState();
            Invoke("SetExplosionState", explosionTime);
            Destroy(other.gameObject);
        }
    }

    void SetExplosionState() {
        if (!explosion.activeSelf) {
            explosion.SetActive(true);
        }
        else {
            explosion.SetActive(false);
        }
    }
}
