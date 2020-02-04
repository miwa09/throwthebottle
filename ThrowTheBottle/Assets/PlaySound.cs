using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    void Sound() {

        gameObject.GetComponent<AudioSource>().Play();

        GetComponent<AudioSource>().Play();

    }
}
