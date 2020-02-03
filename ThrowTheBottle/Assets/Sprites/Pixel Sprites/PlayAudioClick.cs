using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioClick : MonoBehaviour {
    public AudioSource audio;

    void OnMouseDown() {
        if (Input.GetMouseButtonDown(0)) {
            audio.Play();
        }
    }
}
