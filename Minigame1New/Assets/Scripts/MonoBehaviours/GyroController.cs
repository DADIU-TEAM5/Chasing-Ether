using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    public GameObject Water;


    Quaternion lastFrameRotation;
    Quaternion currentFrameRotation;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Input.gyro.enabled = true;
        lastFrameRotation = GyroToUnity(Input.gyro.attitude);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 rotation = Input.gyro.rotationRate;
        //float rotation = Input.GetAxis("Horizontal");

        Water.transform.Rotate(Vector3.forward, rotation.y);


    }


    bool WasPhoneRotated()
    {
        bool returnBool = false;
        currentFrameRotation = GyroToUnity(Input.gyro.attitude);

        if (currentFrameRotation != lastFrameRotation)
            returnBool = true;

        lastFrameRotation = currentFrameRotation;

        return returnBool;

    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
