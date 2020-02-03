using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableSensor : MonoBehaviour
{
    public LayerMask mask;
    GameManager gm;
    public Vector3 spawnLocation;
    public bool explodeOnTimer = false;
    float timer = 0;
    public float explodeTimer = 0.5f;
    bool exploding = false;

    private void Update() {
        if (exploding) {
            timer += Time.deltaTime;
            if (timer >= explodeTimer) {
                Destroy(gameObject);
                return;
            }
        }
    }

    private void OnEnable() {
        gm = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Default") && this.enabled) {
            if (!gm.chaos) {
                gm.gameObject.GetComponent<NormalMode>().Miss();
                this.enabled = false;
                return;
            }
            if (gm.chaos) {
                GameObject.FindGameObjectWithTag("GameLogic").GetComponent<ChaosMode>().AddScoreThrow(transform.position);
                this.enabled = false;
                return;
            }
            if (explodeOnTimer) {
                exploding = true;
            }
        }
    }
}
