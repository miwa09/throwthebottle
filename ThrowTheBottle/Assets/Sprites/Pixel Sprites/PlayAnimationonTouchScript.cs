using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationonTouchScript : MonoBehaviour
{
    public Animation thisAnim;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            thisAnim.Play();
        }
    }
}
