using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{
    public bool chaos = false;

    private void Awake() {
        if (PlayerPrefs.GetInt("mistake") == 1) {
            PlayerPrefs.SetInt("mistake", 2);
            PlayerPrefs.Save();
            SceneManager.LoadScene("ViljamiScene");
            return;
        }
        if (PlayerPrefs.GetInt("mistake") == 2) {
            PlayerPrefs.SetInt("mistake", 3);
            PlayerPrefs.Save();
            SceneManager.LoadScene("ViljamiScene");
            return;
        }
        if (PlayerPrefs.GetInt("mistake") == 3) {
            PlayerPrefs.SetInt("mistake", 4);
            PlayerPrefs.Save();
            SceneManager.LoadScene("ViljamiScene");
            return;
        }
        if (PlayerPrefs.GetInt("mistake") == 4) {
            SceneManager.LoadScene("ViljamiScene");
            return;
        }
    }
    public void ChaosMode() {
        chaos = true;
    }

    public void NormalMode() {
        chaos = false;
    }
}
