using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSound : MonoBehaviour
{
   

    public AK.Wwise.Event EngineLoop;
    public AK.Wwise.Event BoatTurn;
    public AK.Wwise.Event Boost;
    public AK.Wwise.Event CollisionSound;
    public AK.Wwise.Event DistanceToDangerEvent;
    public AK.Wwise.Event CheckpointPickUpEvent;

    public FloatVariable DistanceToDangerVariable;
    bool canPlaySound = true;


    public PlayerController Boat;
    public GameObject BoatTransform;
    //public FloatVariable Speed;
    // public FloatVariable TurnAngle;
    public float RotationSoundAngle;
    public float DistanceToCollisionDebug;


    void Start()
    {
        EngineLoop.Post(gameObject);
        BoatTurn.Post(gameObject);
        DistanceToDangerEvent.Post(gameObject);
    }

   
    void Update()
    {
        // Send speed and angle value to Wwise, controlling engine pitch
        RotationSoundAngle = Mathf.Abs(BoatTransform.transform.localRotation.z * 100);
        AkSoundEngine.SetRTPCValue("BoatTurnAngle", RotationSoundAngle);
        AkSoundEngine.SetRTPCValue("BoatSpeed", Boat.velocity);


        //Send distances from checkpoints and obstacles to wwise, controlling musical elements
        AkSoundEngine.SetRTPCValue("DistanceToNearestObstacle", DistanceToDangerVariable.Value);
        DistanceToCollisionDebug = DistanceToDangerVariable.Value;


        //Debug boost
        /*  if (Input.GetKeyDown("space"))
          {
              Boost.Post(gameObject);
          }
          */
    }

    public void BlowBoost()
    {
        if (canPlaySound)
        {
            Boost.Post(gameObject);
            StartCoroutine(delaySound(1f));
        }
    }

    public void PlayerCollision()
    {
        CollisionSound.Post(gameObject);
    }

    public void CheckpointPickUp()
    {
        CheckpointPickUpEvent.Post(gameObject);
    }

    IEnumerator delaySound (float delay)
    {
        canPlaySound = false;
        yield return new WaitForSeconds(delay);
        canPlaySound = true;
    }


}



