using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationonTouchScript : MonoBehaviour
{
    public Animation thisAnim;
    public AudioSource audio;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            thisAnim.Play();
            audio.Play();
        }
    }
}
