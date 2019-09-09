using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newMicScript : MonoBehaviour
{
    public Text tex;
    string device;
    private AudioClip micRecord;
    // Start is called before the first frame update
    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            int workingdevice = 0;
            for (int i = 0; i < Microphone.devices.Length; i++)
            {

                if (Microphone.devices[i] != null)
                {
                    workingdevice = i;
                }
            }
            device = Microphone.devices[workingdevice];
            micRecord = Microphone.Start(device, true, 5, 44100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float maxVolume = GetMaxVolume();
        tex.text = "" + maxVolume;
        print(maxVolume);
    }

    private float GetMaxVolume()
    {
        print("n0");
        float maxVolume = 0f;
        int sampleSize = 128;
        float[] volumeData = new float[sampleSize];


        int offset = Microphone.GetPosition(device) - sampleSize + 1;
        if (offset < 0)
        {
            return 0;
        }
        micRecord.GetData(volumeData, offset);

        tex.text = "volume level " + volumeData[0];
        for (int i = 0; i < 128; i++)
        {
            float tempMax = volumeData[i];
            if (maxVolume < tempMax)
            {
                maxVolume = tempMax;
            }
        }
        tex.text = "goat";
        return maxVolume;
    }
}
