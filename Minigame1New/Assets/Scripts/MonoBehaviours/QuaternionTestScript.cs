using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuaternionTestScript : MonoBehaviour
{

    //public Text tex;

    public float steeringInput;


    float rotationThreshHold = 15;
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

        currentRot += rotRate;

        if(Mathf.Abs(currentRot) > rotationThreshHold)
        {
            if (currentRot < 0)
            {
                //tex.text = "Left";
                steeringInput = 1;
            }
            else
            {
                //tex.text = "Right";
                steeringInput = -1;
            }
        }
        else
        {
            //tex.text = "Forward";
            steeringInput = 0;
        }


//        tex.text = "" + currentRot;
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
