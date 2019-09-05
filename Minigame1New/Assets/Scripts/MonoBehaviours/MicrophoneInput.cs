using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MicrophoneInput : MonoBehaviour
{
    public int windspeed = 5;
    public int countBackground = 50;
  
    private static float volume;
    private AudioClip micRecord;
    string device;
    public float x,y,z;
    private float backgroundSoundsSum = 0;
    private float backgroundSoundsArv;

    void Start()
    {
        device = Microphone.devices[0];
        micRecord = Microphone.Start(device, true, 5, 44100);
    }
    void Update()
    {
        volume = GetMaxVolume();
        x = gameObject.transform.position.x;
		y = gameObject.transform.position.y;
		z = gameObject.transform.position.z;

        if (Time.frameCount < countBackground)
            backgroundSoundsSum += volume;
        else if(Time.frameCount == countBackground)
        {
            backgroundSoundsSum += volume;
            backgroundSoundsArv = backgroundSoundsSum / countBackground;
        }
        else
            MoveObject();
    }


    private void MoveObject()
    {
        if (volume -0.2 > backgroundSoundsArv)
        {
            volume = volume * windspeed * Time.deltaTime;
            gameObject.transform.position = new Vector3(x, y + volume * 10, 0);
        }
        else
        {
            gameObject.transform.position = new Vector3(x, y, 0);
        }
    }
  
    private float GetMaxVolume()
    {
        float maxVolume = 0f;
        int sampleSize = 128;
        float[] volumeData = new float[sampleSize];
        int offset = Microphone.GetPosition(device) - sampleSize + 1;
        if (offset < 0)
        {
            return 0;
        }
        micRecord.GetData(volumeData, offset);

        for (int i = 0; i < 128; i++)
        {
            float tempMax = volumeData[i];
            if (maxVolume < tempMax)
            {
                maxVolume = tempMax;
            }
        }
        return maxVolume;
    }

}
