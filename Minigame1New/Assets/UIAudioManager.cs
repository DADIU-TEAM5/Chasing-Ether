using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioManager : MonoBehaviour
{

    public AK.Wwise.Event OpenMenu;
    public AK.Wwise.Event CloseMenu;
    public AK.Wwise.Event Select;

    




    void Start()
    {
       // AkSoundEngine.SetState("MenuOrNot", "Game");
    }


    // Update is called once per frame
    void Update()
    {
     


    }

    public void SetVolumeSound(float vol)
    {
        var akValue = -96 + (96 * vol);
        AkSoundEngine.SetRTPCValue("EverythingElseVCAControl", akValue);
    }

    public void SetVolumeMusic(float vol)
    {
        var akValue = -96 + (96 * vol);
        AkSoundEngine.SetRTPCValue("MusicVCAControl", akValue);
    }

    public void OpenMenuEvent()
    {
        Debug.Log("PlayMenuEvent");
        OpenMenu.Post(gameObject);
        AkSoundEngine.SetState("MenuOrNot", "Menu");
    }

    public void CloseMenuEvent()
    {
        CloseMenu.Post(gameObject);
        AkSoundEngine.SetState("MenuOrNot", "Game");
    }

    public void SelectEvent()
    {
        Select.Post(gameObject);
    }

    }
