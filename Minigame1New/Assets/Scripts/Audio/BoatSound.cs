using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSound : MonoBehaviour
{
   

    public AK.Wwise.Event EngineLoop;
    public AK.Wwise.Event BoatTurn;
    public FloatVariable Speed;
    public FloatVariable TurnAngle;

    void Start()
    {
        EngineLoop.Post(gameObject);
    }

    void Update()
    {
        // Send speed value to Wwise, controlling engine pitch
        AkSoundEngine.SetRTPCValue("BoatSpeed", Speed.Value);
        AkSoundEngine.SetRTPCValue("BoatTurnAngle", TurnAngle.Value);
    }
}
