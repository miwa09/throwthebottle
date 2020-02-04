using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecretTextEffect : MonoBehaviour
{
    public TextMeshProUGUI text;
    float dilate = 0;
    float timer = 0;
    float timer2 = 0;
    float softness = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.25f) {
            timer -= 0.25f;
            dilate += Random.Range(-0.1f, 0.1f);
            dilate = Mathf.Clamp(dilate, -1, 1);
            text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, dilate);
        }
        timer2 += Time.deltaTime;
        if (timer2 >= 0.125f) {
            timer2 -= 0.125f;
            softness += Random.Range(-0.05f, 0.05f);
            softness = Mathf.Clamp(softness, 0, 1);
            text.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineSoftness, softness);
        }
    }
}
