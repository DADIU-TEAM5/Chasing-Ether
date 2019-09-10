using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update

    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    public GameObject menuParrent;

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
    public void startScene(int sceneNumber)
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

}
