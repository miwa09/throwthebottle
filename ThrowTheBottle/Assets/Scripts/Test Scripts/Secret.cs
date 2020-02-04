using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Secret : MonoBehaviour
{
    int clicks = 0;
    public void Click() {
        clicks++;
        if (clicks >= 12) {
            SceneManager.LoadScene("ViljamiScene");
        }
    }
}
