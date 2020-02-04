using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{
    public bool chaos = false;

    public void ChaosMode() {
        chaos = true;
    }

    public void NormalMode() {
        chaos = false;
    }
}
