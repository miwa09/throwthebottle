using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTest : MonoBehaviour
{
    private void Awake() {
        PlayerPrefs.SetString("testi", "poo");
        PlayerPrefs.Save();
    }
}
