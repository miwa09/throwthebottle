using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecretTextAnimation : MonoBehaviour
{
    public string stringToType = "Test...";
    public TextMeshProUGUI text;
    public float timeInBetween = 0.15f;
    void Start()
    {
        Clear();
        StartCoroutine("AutoType");
    }

    IEnumerator AutoType() {
        foreach (char letter in stringToType.ToCharArray()) {
            text.text += letter;
            yield return new WaitForSeconds(timeInBetween);
        }
    }

    public void Clear() {
        text.text = "";
        stringToType = "";
        StopAllCoroutines();
    }

    public void EntityType(string text) {
        Clear();
        stringToType = text;
        StartCoroutine("AutoType");
    }

    public void Forever() {
        EntityType("forver");
    }
}
