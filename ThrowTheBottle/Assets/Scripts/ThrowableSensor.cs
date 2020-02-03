using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableSensor : MonoBehaviour
{
    public LayerMask mask;
    GameManager gm;
    public Vector3 spawnLocation;

    private void OnEnable() {
        gm = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Default") && this.enabled) {
            if (!gm.chaos) {
                gm.gameObject.GetComponent<NormalMode>().Miss();
                this.enabled = false;
            }
            if (gm.chaos) {
                GameObject.FindGameObjectWithTag("GameLogic").GetComponent<ChaosMode>().AddScoreThrow(transform.position);
                this.enabled = false;
            }
        }
    }
}
