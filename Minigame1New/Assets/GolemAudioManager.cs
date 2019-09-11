using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAudioManager : MonoBehaviour
{
    public AK.Wwise.Event GolemStep;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GolemStepEvent()
    {
        GolemStep.Post(gameObject);
    }


}
