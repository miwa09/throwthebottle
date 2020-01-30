using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableSensor : MonoBehaviour
{
    public LayerMask mask;
    GameManager gm;
    bool chaos = false;

    private void OnEnable() {
        gm = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameManager>();
        if (gm.chaos) {
            chaos = true;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == mask) {
            if (!chaos) {
                gm.gameObject.GetComponent<NormalMode>().Miss();
                this.enabled = false;
            }
        }
    }
}
