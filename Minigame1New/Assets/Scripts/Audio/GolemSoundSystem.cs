using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSoundSystem : MonoBehaviour
{

    public AK.Wwise.Event Step;
    public AK.Wwise.Event Voice;

    // Start is called before the first frame update
    void Start()
    {
        //Voice.Post(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GolemStepPlaySound()
    {
        Step.Post(gameObject);
    }
}
