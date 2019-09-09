using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Sprite mute;
    public Sprite low;
    public Sprite middle;
    public Sprite high;

    public void pressUI()
    {
        bool originalState = gameObject.activeSelf;
        gameObject.SetActive(!originalState);
    }

    public void volumeCheck()
    {
        GameObject sliderGO = transform.Find("Slider").gameObject;
        GameObject imageGO = transform.Find("Image").gameObject;
        Slider slider = sliderGO.GetComponent<Slider>();
        Image image = imageGO.GetComponent <Image> ();
        /*
        Sprite mute = Resources.Load<Sprite>("Assets/Christians stuff/UI/Sprites/Icon_Sound_Off");
        Sprite low = Resources.Load<Sprite>("Assets/Christians stuff/UI/Sprites/Icon_Sound_1");
        Sprite middle = Resources.Load<Sprite>("Assets/Christians stuff/UI/Sprites/Icon_Sound_2");
        Sprite high = Resources.Load<Sprite>("Assets/Christians stuff/UI/Sprites/Icon_Sound_3");
        */
        
        
        if (slider.value < Mathf.Epsilon)
            image.sprite = mute;
        else if (slider.value < 0.33)
            image.sprite = low;
        else if (slider.value < 0.66)
            image.sprite = middle;
        else
            image.sprite = high;
    }

    public void flatPop()
    {
        GameObject[] popList = GameObject.FindGameObjectsWithTag("pop");
        if (popList != null)
            foreach (GameObject cp in popList)
                if (cp.activeSelf)
                {
                    cp.SetActive(false);
                }
    }

    public void loadHome()
    {
        SceneManager.LoadScene(0);
    }

}
