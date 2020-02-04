using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFade : MonoBehaviour
{
    public GameObject panelOn;
    public GameObject panelOff;

    public void Animate() {
        if (GetComponent<Animation>().isPlaying) {
            GetComponent<Animation>().Stop();
        }
        GetComponent<Animation>().Play();
    }
    public void ChangeMenuPanels() {
        panelOn.SetActive(true);
        panelOff.SetActive(false);
    }
}
