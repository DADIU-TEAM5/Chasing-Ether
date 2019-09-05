using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{

    public string micVolText;

    // Start is called before the first frame update
    void Start()
    {
        micVolText = GameObject.Find("Boat").GetComponent<MicrophoneInputv2>().volume.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = micVolText;
    }
}
