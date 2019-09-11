using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MultiInstantiater : MonoBehaviour
{
    public GameObject[] SoundObjects;

    void Awake()
    {
        for (int i = 0; i < SoundObjects.Length; i++) {
            Instantiate(SoundObjects[i]);
        }
    }
}

