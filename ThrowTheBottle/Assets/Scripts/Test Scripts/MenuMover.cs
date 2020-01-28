using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMover : MonoBehaviour
{
    public float moveMultiplier = 0.3f;
    public float maxHorizontalMovement = 75f;
    bool reachedEndL = false;
    bool reachedEndR = false;
    bool getOnce = true;
    Vector3 inertia;
    void Update()
    {
        Vector3 touchChange = Input.touches[0].deltaPosition;
        if (Input.touchCount > 0 && !reachedEndL && !reachedEndR) {
            if (transform.position.x < maxHorizontalMovement && transform.position.x > -maxHorizontalMovement) {
                transform.position += new Vector3(touchChange.x * moveMultiplier, 0, 0);
            }
            if (Input.touches[0].phase == TouchPhase.Ended) {
                if (getOnce) {
                    inertia = touchChange;
                    getOnce = false;
                }
            }
        }
        if (transform.position.x >= maxHorizontalMovement) {
            transform.position = new Vector3(maxHorizontalMovement, 0, 0);
            reachedEndR = true;
        }
        if (transform.position.x <= -maxHorizontalMovement) {
            transform.position = new Vector3(-maxHorizontalMovement, 0, 0);
            reachedEndL = true;
        }
        if (reachedEndL) {
            if (transform.position.x + touchChange.x > -maxHorizontalMovement) {
                transform.position += new Vector3(touchChange.x * moveMultiplier, 0, 0);
                reachedEndL = false;
            }
        }
        if (reachedEndR) {
            if (transform.position.x + touchChange.x < maxHorizontalMovement) {
                transform.position += new Vector3(touchChange.x * moveMultiplier, 0, 0);
                reachedEndR = false;
            }
        }
        Inertia();
    }

    void Inertia() {
        if (!reachedEndL && !reachedEndR) {
            transform.position += new Vector3(inertia.x * moveMultiplier, 0, 0);
            //inertia -= new Vector3(inertia.x * Time.deltaTime, 0, 0);
            //if (inertia.x < 0.01f) {
            //    inertia = Vector3.zero;
            //}
        } else {
            inertia = Vector3.zero;
            return;
        }
    }
}
