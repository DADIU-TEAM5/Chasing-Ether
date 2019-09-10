using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSound : MonoBehaviour
{
   

    public AK.Wwise.Event EngineLoop;
    public AK.Wwise.Event BoatTurn;
    public PlayerController Boat;
    public GameObject BoatTransform;
    //public FloatVariable Speed;
    // public FloatVariable TurnAngle;
    public float RotationSoundAngle;


    void Start()
    {
        EngineLoop.Post(gameObject);
        BoatTurn.Post(gameObject);
    }

   
    void Update()
    {
        // Send speed value to Wwise, controlling engine pitch
        // AkSoundEngine.SetRTPCValue("BoatSpeed", Speed.Value);

        RotationSoundAngle = Mathf.Abs(BoatTransform.transform.localRotation.z * 100);
        AkSoundEngine.SetRTPCValue("BoatTurnAngle", RotationSoundAngle);
        AkSoundEngine.SetRTPCValue("BoatSpeed", Boat.velocity);


    }
}
