using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerJoni : MonoBehaviour
{
    public GameObject levelCompleteUI;

    public void LevelComplete() {
            levelCompleteUI.SetActive(true);
        //Debug.Log("voitit pelin");
    }
}
