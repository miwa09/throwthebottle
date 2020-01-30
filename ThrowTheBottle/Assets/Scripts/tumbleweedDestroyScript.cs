using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tumbleweedDestroyScript : MonoBehaviour
{
    // Start is called before the first frame update


    public float destroyTime;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

}
