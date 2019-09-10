using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroController : MonoBehaviour
{
    public float steeringInput;

    //public Text tex;


    float timer = 0;

    float rotationThreshHold = 0.2f;
    float currentRot = 0;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Input.gyro.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        float rotRate = Input.gyro.rotationRate.y;

        currentRot += rotRate *Time.deltaTime;

        if (Mathf.Abs(currentRot) > rotationThreshHold)
        {
            //timer = 0;
            if (currentRot < 0)
            {
                //tex.text = "Left";
                steeringInput = -1;
            }
            else
            {
                //tex.text = "Right";
                steeringInput = 1;
            }
        }
        else
        {
            //timer += Time.deltaTime;
            //tex.text = "Forward";
            steeringInput = 0;
           // currentRot = 0;
            /*
            if (timer > 0.6f)
            {
                currentRot = 0;
                timer = 0;
            }
            */
           // currentRot = currentRot * 0.9f;
            
        }


               // tex.text = "" + currentRot;
    }
}
