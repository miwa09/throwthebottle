using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestThrow : MonoBehaviour
{
    Rigidbody rig;
    public Vector3 direction;
    public float distanceMultiplier;
    public float vertMultiplier;
    public float horMultiplier;
    Vector3 startPos;
    Quaternion startRot;
    public bool PCTest = false;
    bool doOnce = true;
    Vector2 touchLastPos;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void Update()
    {
        GetTouchVelocity();
        if (PCTest) {
            KeyboardTest();
        }
    }

    void KeyboardTest() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rig.AddForce(new Vector3(direction.x * distanceMultiplier, direction.y * vertMultiplier, direction.z * horMultiplier), ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            rig.velocity = Vector3.zero;
            rig.angularVelocity = Vector3.zero;
            rig.position = startPos;
            rig.rotation = startRot;
        }
    }

    void GetTouchVelocity() {
        if (Input.touchCount > 0) {
            if (doOnce) {
                touchLastPos = Input.touches[0].position;
                doOnce = false;
            }
            Vector2 touchPosChange = Input.touches[0].position - touchLastPos;
            touchLastPos = Input.touches[0].position;
            if (Input.touches[0].phase == TouchPhase.Ended) {
                TouchAddForce(touchPosChange);
                doOnce = true;
                //this.enabled = false;
            }
        } else return;
    }

    void TouchAddForce(Vector3 force) {
        rig.AddForce(new Vector3(force.y * distanceMultiplier, force.y * vertMultiplier, -force.x * horMultiplier), ForceMode.Impulse);
    }

    public void ResetBall() {
        rig.velocity = Vector3.zero;
        rig.angularVelocity = Vector3.zero;
        rig.position = startPos;
        rig.rotation = startRot;
    }
}
