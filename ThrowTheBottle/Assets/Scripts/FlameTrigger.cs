using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrigger : MonoBehaviour
{
    public GameObject explosion;
    public float explosionRadius = 2f;
    public float explosionTime = 0.5f;

    //private void OnTriggerEnter(Collider other) {
    //    if(other.gameObject.tag == "throwable") {
    //        SetExplosionState();
    //        Invoke("SetExplosionState", explosionTime);
    //        Destroy(other.gameObject);
    //    }
    //}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default")) {
            Collider[] objsToDestroy = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider obj in objsToDestroy) {
                if (obj.CompareTag("destroyable") && obj.GetComponent<IDestroyable>() != null) {
                    obj.GetComponent<IDestroyable>().DestroyObj();
                }
                SetExplosionState();
                Invoke("SetExplosionState", explosionTime);
                Destroy(gameObject);
            }
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
