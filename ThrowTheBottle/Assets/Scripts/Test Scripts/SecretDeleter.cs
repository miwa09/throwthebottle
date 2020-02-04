using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDeleter : MonoBehaviour
{
    public bool isEnabled;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default") && isEnabled) {
            Destroy(gameObject);
        }
    }
}
