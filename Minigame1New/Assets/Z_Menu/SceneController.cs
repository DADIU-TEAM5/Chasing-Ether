using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update

    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    public GameObject menuParrent;
    public int sceneNumber;

    public Text text;

    void Start()
    {
        //myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/scenes");
        //scenePaths = myLoadedAssetBundle.GetAllScenePaths();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Called when a level is selected from the menu
    // TODO Add the relevant levels
    public void startScene()
    {

        print("Enter scene");

        if (sceneNumber == 1)
        {
            print("Loading LevelDesignScene_2");
            SceneManager.LoadScene("LevelDesignScene_2", LoadSceneMode.Additive);

            Destroy(menuParrent);

            print("Changing to LevelDesignScene_2");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("LevelDesignScene_2"));

           
        }
      
       
    }

    public void goLeft()
    {
        if (sceneNumber > 0)
            sceneNumber--;
        print("Left :" + sceneNumber);
        changeText();
    }

    public void goRigth()
    {
        if (sceneNumber < 3)
            sceneNumber++;
        print("Right :" + sceneNumber);
        changeText();
    }

    public void changeText()
    {
        string level;
        if (sceneNumber == 0)
        {
            level = "Tutorial";
        }
        else
        {
            level = "Level " + sceneNumber;
        }
        
        text.text = level;
    }

}
