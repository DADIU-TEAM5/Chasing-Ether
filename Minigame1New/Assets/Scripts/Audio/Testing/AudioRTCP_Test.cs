using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRTCP_Test : MonoBehaviour
{

    public AK.Wwise.Event BoatMotor;
    [Range(0f, 100f)]
    public float DistanceToDanger;

    [Range(0f, 100f)]
    public float DistanceToCheckpoint;

    [Range(0f, 100f)]
    public float BoatSpeed;

    [Range(0f, 100f)]
    public float BoatTurnAngle;

    void Start()
    {
        BoatMotor.Post(gameObject);
    }

     void Update()
    {

        AkSoundEngine.SetRTPCValue("DistanceToNearestObstacle", DistanceToDanger);
        AkSoundEngine.SetRTPCValue("DistanceToCheckpoint", DistanceToCheckpoint);
        AkSoundEngine.SetRTPCValue("BoatSpeed", BoatSpeed);
        AkSoundEngine.SetRTPCValue("BoatTurnAngle", BoatTurnAngle);



    }
}
