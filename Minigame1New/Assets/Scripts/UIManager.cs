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

    public GameEvent clickSoundEvent;
    public GameEvent openMenuEvent;
    public GameEvent closeMenuEvent;

    public Slider MusicSlider;
    public Slider AudioSlider;
    public Image image;
    public UIAudioManager UIAudioManager;

    public void pressUI()
    {
        bool originalState = gameObject.activeSelf;
        gameObject.SetActive(!originalState);

        clickSoundEvent.Raise();
    }

    public void playAnimation()
    {
        Animator animator;
        bool animatorStatus;
        animator = GetComponent<Animator>();
        animatorStatus =animator.GetBool("isOpen");
        animator.SetBool("isOpen", !animatorStatus);
        if (animatorStatus)
        {
            closeMenuEvent.Raise();
        }
        else
        {
            openMenuEvent.Raise();
        }

    }

    public void volumeCheck()
    {
        
        var audioSliderValue = AudioSlider.value;
        var musicSliderValue = MusicSlider.value;
        /*
        Sprite mute = Resources.Load<Sprite>("Assets/Christians stuff/UI/Sprites/Icon_Sound_Off");
        Sprite low = Resources.Lokad<Sprite>("Assets/Christians stuff/UI/Sprites/Icon_Sound_1");
        Sprite middle = Resources.Load<Sprite>("Assets/Christians stuff/UI/Sprites/Icon_Sound_2");
        Sprite high = Resources.Load<Sprite>("Assets/Christians stuff/UI/Sprites/Icon_Sound_3");
        */
        
        
        if (audioSliderValue < Mathf.Epsilon)
            image.sprite = mute;
        else if (audioSliderValue < 0.33)
            image.sprite = low;
        else if (audioSliderValue < 0.66)
            image.sprite = middle;
        else
            image.sprite = high;

        UIAudioManager.SetVolumeMusic(MusicSlider.value);
        UIAudioManager.SetVolumeSound(AudioSlider.value);
    }

    public void volumeMusicCheck()
    {

        var audioSliderValue = AudioSlider.value;
        var musicSliderValue = MusicSlider.value;
        /*
        Sprite mute = Resources.Load<Sprite>("Assets/Christians stuff/UI/Sprites/Icon_Sound_Off");
        Sprite low = Resources.Lokad<Sprite>("Assets/Christians stuff/UI/Sprites/Icon_Sound_1");
        Sprite middle = Resources.Load<Sprite>("Assets/Christians stuff/UI/Sprites/Icon_Sound_2");
        Sprite high = Resources.Load<Sprite>("Assets/Christians stuff/UI/Sprites/Icon_Sound_3");
        */

        UIAudioManager.SetVolumeMusic(MusicSlider.value);
        UIAudioManager.SetVolumeSound(AudioSlider.value);
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
        SceneManager.LoadScene("MenuScene2");
    }

}
