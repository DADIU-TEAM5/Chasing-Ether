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
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenuEvent()
    {
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
