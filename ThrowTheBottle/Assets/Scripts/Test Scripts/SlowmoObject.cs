using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowmoObject : MonoBehaviour
{
    bool active = false;
    public float maxSlow = 0.5f;
    public float timeToMax = 1;

    void Update()
    {
        if (active) {
            SlowMo();
        } else RegularMo();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("throwable")) {
            active = true;
            Camera.main.gameObject.GetComponent<CameraZoom>().active = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("throwable")) {
            active = false;
            Camera.main.gameObject.GetComponent<CameraZoom>().active = false;
        }
    }

    void SlowMo() {
        if (Time.timeScale > maxSlow) {
            Time.timeScale -= Time.deltaTime * 5;
        }
        if (Time.timeScale < maxSlow) {
            Time.timeScale = maxSlow;
        }
    }

    void RegularMo() {
        if (Time.timeScale < 1) {
            Time.timeScale += Time.deltaTime * 2;
        }
        if (Time.timeScale > 1) {
            Time.timeScale = 1;
        }
    }
}
