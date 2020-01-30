using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiotrigger_breakables : MonoBehaviour
{
    public AudioClip soundtoplay;
    public float Volume;
    AudioSource sound;
    public bool AlreadyPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter()
    {

        if (!AlreadyPlayed)
        {
            sound.PlayOneShot(soundtoplay, Volume);
            AlreadyPlayed = true;
        }

    }
}
// Update is called once per frame

