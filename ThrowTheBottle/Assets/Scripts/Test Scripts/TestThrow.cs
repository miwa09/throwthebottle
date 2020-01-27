using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestThrow : MonoBehaviour
{
    Rigidbody rig;
    public Vector3 direction;
    public float distanceMultiplier;
    public float vertMultiplier;
    public float horMultiplier;
    public float maxHorizontal = 10;
    public float maxVertical = 10;
    Vector3 startPos;
    Vector2 touchPosChange;
    Quaternion startRot;
    public bool PCTest = false;
    bool doOnce = true;
    Vector2 touchLastPos;
    public Text test;

    void Start()
    {
        touchPosChange = Vector2.zero;
        rig = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void Update()
    {
        test.text = "" + touchPosChange.x + "," + touchPosChange.y;
        GetTouchVelocity();
        if (PCTest) {
            KeyboardTest();
        }
    }

    void KeyboardTest() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rig.AddForce(new Vector3(direction.x * distanceMultiplier, direction.y * vertMultiplier, direction.z * horMultiplier), ForceMode.Impulse);
            this.enabled = false;
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
            touchPosChange = Input.touches[0].position - touchLastPos;
            touchPosChange.x = Mathf.Clamp(touchPosChange.x, -maxHorizontal, maxHorizontal);
            touchPosChange.y = Mathf.Clamp(touchPosChange.y, 0, maxVertical);
            touchLastPos = Input.touches[0].position;
            if (touchPosChange.y >= maxVertical) {
                TouchAddForce(touchPosChange);
                this.enabled = false;
                return;
            }
            if (Input.touches[0].phase == TouchPhase.Ended) {
                TouchAddForce(touchPosChange);
                if (touchPosChange.magnitude < 1) {
                    return;
                }
                this.enabled = false;
                return;
            }
        } else return;
    }

    void TouchAddForce(Vector3 force) {
        rig.AddForce(new Vector3(force.y * distanceMultiplier, force.y * vertMultiplier, -force.x * horMultiplier), ForceMode.Impulse);
    }

    //public void ResetBall() {
    //    rig.velocity = Vector3.zero;
    //    rig.angularVelocity = Vector3.zero;
    //    rig.position = startPos;
    //    rig.rotation = startRot;
    //    canDo = false;
    //}
}
