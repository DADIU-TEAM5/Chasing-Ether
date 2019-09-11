using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AK.Wwise.Event GameMusic;

    //[Range(1, 3)]
    public FloatVariable DistanceToGiant;

    void Start()
    {
        GameMusic.Post(gameObject);

        AkSoundEngine.SetState("DistanceToGiant", "Far");


    }



    void Update()
    {
        /*
        if (DistanceToGiant.Value is 1)
        {
            AkSoundEngine.SetState("DistanceToGiant", "Far");
        }

        if (DistanceToGiant.Value is 2)
        {
            AkSoundEngine.SetState("DistanceToGiant", "Closer");
        }

        if (DistanceToGiant.Value is 3)
        {
            AkSoundEngine.SetState("DistanceToGiant", "Closest");
        }*/
    }
}
