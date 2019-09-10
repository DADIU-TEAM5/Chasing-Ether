using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameOver : MonoBehaviour
{
    public IntVariable SceneToLoad;

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(SceneToLoad.Value);
    }
}
