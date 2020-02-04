using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBall : MonoBehaviour
{
    public Transform[] locationList;
    Vector3 targetLocation;
    public float speed = 3f;
    int lastIndex = 0;
    bool evade = false;
    Vector3 evasionVector;

    private void Start() {
        targetLocation = transform.position;
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.L)) {
            Dodge();
        }
        if (Moving() && !evade) {
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, Time.deltaTime * speed);
        }
        if (evade) {
            Evasion();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("thrown")) {
            Dodge();
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("thrown")) {
            evasionVector = other.transform.position;
            evade = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("thrown")) {
            evade = false;
        }
    }

    bool Moving() {
        if (Vector3.Distance(targetLocation, transform.position) < 0.1f) {
            return false;
        } else return true;
    }

    void Dodge() {
        int i = Random.Range(0, locationList.Length);
        if (i == lastIndex) {
            Dodge();
            return;
        }
        lastIndex = i;
        targetLocation = locationList[i].position;
    }

    void Evasion() {
        Vector3 evasionDirection = transform.position - evasionVector;
        transform.position += new Vector3(evasionVector.x, 0, evasionVector.z) * Time.deltaTime;
    }
}
