﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    void Sound() {
        GetComponent<AudioSource>().Play();
    }
}
