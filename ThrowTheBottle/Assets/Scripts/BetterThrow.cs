using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetterThrow : MonoBehaviour
{
    //public int framesToRemember = 6;
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
    public bool thrown = false;
    Vector3 lastPosition;
    bool canThrow = false;
    public bool ended = false;

    private void Start() {
        rig = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!ended) {
            //if (Input.GetKeyDown(KeyCode.Space)) {
            //    LeaveSpawn();
            //}
            if (canThrow && !thrown) {
                DragAlong();
            }
            if (Input.touchCount > 0 && canThrow && !thrown) {
                touchDelta.Add(Input.touches[0].deltaPosition);
                framesCounted++;
            }
        }
    }

    private void LateUpdate() {
        //SoftReset();
        if (Input.touchCount > 0 && canThrow && !thrown) {
            if (Input.touches[0].phase == TouchPhase.Ended) {
                rig.isKinematic = false;
                lastPosition = transform.position;
                int i = 0;
                while (i < touchDelta.Count) {
                    throwForce += touchDelta[i];
                    i++;
                }
                Throw(CalculateForce(throwForce));
                framesCounted = 0;
                throwForce = Vector3.zero;
                touchDelta.Clear();
                thrown = true;
            }
        }
    }

    void DragAlong() {
        if (Input.touchCount > 0) {
            rig.isKinematic = true;
            Touch touch = Input.GetTouch(0);
            Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1.75f));
            rig.position = touchedPos;
        }
    }

    void SoftReset() {
        if (touchDelta.Count > 6) {
            if ((touchDelta[framesCounted] + touchDelta[framesCounted - 5]).magnitude < softResetDeadzone) {
                touchDelta.Clear();
            }
        }
    }

    void Throw(Vector3 force) {
        rig.AddForce(force, ForceMode.VelocityChange);
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
        return new Vector3(forward, vertical, -horizontal);
    }

    public void LeaveSpawn() {
        tag = "thrown";
        if (!ended) {
            GameObject.FindGameObjectWithTag("spawner").GetComponent<ISpawner>().Spawn();
        }
        if (GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameManager>().chaos) {
            GameObject.FindGameObjectWithTag("GameLogic").GetComponent<ChaosMode>().throws++;
        }
        GetComponent<ThrowableSensor>().enabled = true;
        this.enabled = false;
    }

    private void OnCollisionEnter(Collision collision) {
        if (!ended && this.enabled) {
            thrown = false;
            canThrow = true;
        }
    }
}
