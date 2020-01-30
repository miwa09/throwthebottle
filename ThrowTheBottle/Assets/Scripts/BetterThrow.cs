using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterThrow : MonoBehaviour
{
    public int framesToRemember = 6;
    List<Vector3> touchDelta = new List<Vector3>();
    Vector3 throwForce;
    Rigidbody rig;
    int framesCounted = 0;
    public float softResetDeadzone = 0.1f;
    public float deadzone = 1;
    public float forwardMultiplier = 1;
    public float verticalMultiplier = 1;
    public float horizontalMultiplier = 1;
    public float forwardMax = 20;
    public float verticalMax = 10;
    public float horizontalMax = 8;
    bool thrown = false;
    Vector3 lastPosition;

    private void Start() {
        rig = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (thrown) {
            if (transform.position != lastPosition) {
                this.enabled = false;
            } else thrown = false;
        }
        if (Input.touchCount > 0 && !thrown) {
            touchDelta.Add(Input.touches[0].deltaPosition);
            framesCounted++;
        }
    }

    private void LateUpdate() {
        SoftReset();
        if (Input.touchCount > 0) {
            if (Input.touches[0].phase == TouchPhase.Ended) {
                Throw(CalculateForce(throwForce));
                framesCounted = 0;
                throwForce = Vector3.zero;
                touchDelta.Clear();
                thrown = true;
                lastPosition = transform.position;
            }
        }
    }

    void SoftReset() {
        if (framesCounted > 1) {
            if ((touchDelta[framesCounted] + touchDelta[framesCounted - 1]).magnitude < softResetDeadzone) {
                touchDelta.Clear();
            }
        }
    }

    void Throw(Vector3 force) {
        rig.AddForce(force, ForceMode.Impulse);
    }

    Vector3 CalculateForce(Vector3 force) {
        float forward = Mathf.Clamp(force.y / framesCounted * forwardMultiplier, 0, forwardMax);
        float vertical = Mathf.Clamp(force.y * verticalMultiplier, 0, verticalMax);
        float horizontal = Mathf.Clamp(force.x * horizontalMultiplier, -horizontalMax, horizontalMax);
        if (forward < deadzone) {
            forward = 0;
            vertical = 0;
            horizontal = 0;
        }
        return new Vector3(forward, vertical, horizontal);
    }
}
