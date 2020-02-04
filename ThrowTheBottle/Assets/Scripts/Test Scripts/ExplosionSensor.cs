using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSensor : MonoBehaviour
{
    public float requiredVelocity = 8f;
    public Collider[] colliders;
    public GameObject explosionTrigger;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("thrown")) {
            print("hit");
            if (other.GetComponent<Rigidbody>().velocity.magnitude > requiredVelocity) {
                foreach (Collider obj in colliders) {
                    obj.enabled = false;
                }
                explosionTrigger.SetActive(true);
                //print("just right");
            } else {
                //print("nice try");
                foreach (Collider obj in colliders) {
                    obj.enabled = true;
                }
                explosionTrigger.SetActive(false);
            }
        }
    }
}
