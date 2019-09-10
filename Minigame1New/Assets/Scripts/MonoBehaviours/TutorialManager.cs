using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GyroController Gyro;
    public MicrophoneInput Microphone;

    public GameEvent StartBlowUI;
    public GameEvent EndBlowUI;

    public GameEvent StartTiltUI;
    public GameEvent EndTiltUI;

    public string TutorialLevelName;

    void Start() {
        StartCoroutine(Tutorial(TutorialLevelName));
    }


    IEnumerator Tutorial(string tutorialLevelName) {
        yield return new WaitForSeconds(2);

        StartBlowUI.Raise();

        yield return new WaitForSeconds(2);

        if (!Microphone.soundIsActivated) {
            yield return null;
        }

        Debug.Log("Microphone input (y)");

        EndBlowUI.Raise();
        
        yield return new WaitForSeconds(2);

        StartTiltUI.Raise();

        if (Gyro.steeringInput == 0f) {
            yield return null;
        }

        Debug.Log("Gyro input (y)");

        yield return new WaitForSeconds(2);  

        EndTiltUI.Raise();

        yield return new WaitForSeconds(3);  

        SceneManager.LoadScene(tutorialLevelName);
    }
}
