using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationonTouchScript : MonoBehaviour
{
    public Animation thisAnim;
    public AudioSource audio;
    int presses = 0;
    public int timestoPress;
    public bool pressEnabled = true;

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && pressEnabled) {

            presses++;
            Debug.Log("Pressed " + presses + " times");
            if (presses > timestoPress) {
                thisAnim.Play();
                audio.Play();
                pressEnabled = false;
            }
        }
    }
}
