using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTest2 : MonoBehaviour
{
    private void Start() {
       print(PlayerPrefs.GetString("testi"));
    }
}
