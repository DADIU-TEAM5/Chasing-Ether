using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSfxDebugger : MonoBehaviour
{

    public AK.Wwise.Event BoatMotor;
    public FloatVariable BoatSpeed;


    // Start is called before the first frame update
    void Start()
    {

        BoatMotor.Post(gameObject);

    }

    // Update is called once per frame
    void Update()
    {

        AkSoundEngine.SetRTPCValue("BoatSpeed", BoatSpeed.Value);
        
    }
}
