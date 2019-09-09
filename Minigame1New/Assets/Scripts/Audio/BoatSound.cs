using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSound : MonoBehaviour
{
   

    AK.Wwise.Event EngineLoop;
    public FloatVariable Speed;

    void Start()
    {
        EngineLoop.Post(gameObject);
    }

    void Update()
    {
        // Send speed value to Wwise, controlling engine pitch
        AkSoundEngine.SetRTPCValue("BoatSpeed", Speed.Value);
   
    }
}
