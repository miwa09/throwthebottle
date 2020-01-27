using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    public float explosionForce;
    public float explosionRadius;
    public Rigidbody[] affectedRigs;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("throwable")) {
            foreach (Rigidbody rb in affectedRigs) {
                rb.isKinematic = false;
                rb.AddExplosionForce(explosionForce, other.transform.position, explosionRadius);
            }
        }
    }
}
