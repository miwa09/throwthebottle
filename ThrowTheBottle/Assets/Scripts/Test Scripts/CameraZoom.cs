using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    Vector3 resetForward;
    public bool active = false;
    public float minFOV = 15;
    float resetFOV;
    GameObject objToFollow;
    void Start()
    {
        resetFOV = Camera.main.fieldOfView;
        resetForward = transform.forward;
    }

    void Update()
    {
        objToFollow = GameObject.FindGameObjectWithTag("throwable");
        if (active) {
            Zoom();
        } else ResetZoom();
    }

    void Zoom() {
        transform.forward = Vector3.MoveTowards(transform.forward, (objToFollow.transform.position - transform.position).normalized, Time.deltaTime * 1.5f);
        if (Camera.main.fieldOfView > minFOV) {
            Camera.main.fieldOfView -= Time.deltaTime * 100;
        }
        if (Camera.main.fieldOfView < minFOV) {
            Camera.main.fieldOfView = minFOV;
        }
    }

    void ResetZoom() {
        transform.forward = Vector3.MoveTowards(transform.forward, resetForward, Time.deltaTime * 2);
        if (Camera.main.fieldOfView < resetFOV) {
            Camera.main.fieldOfView += Time.deltaTime * 200;
        }
        if (Camera.main.fieldOfView > resetFOV) {
            Camera.main.fieldOfView = resetFOV;
        }
    }
}
