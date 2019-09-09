using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buttonHandler : MonoBehaviour
{
    public Button yourButton;
    public RawImage image;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        print("You have clicked the button!");
        image.GetComponent<Animator>().SetBool("pressedTitle", true);
    }
}