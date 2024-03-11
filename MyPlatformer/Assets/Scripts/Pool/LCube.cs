using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Invoke("Destr", 5f);
    }

    private void Destr()
    {
       gameObject.SetActive(false);
    }
}
