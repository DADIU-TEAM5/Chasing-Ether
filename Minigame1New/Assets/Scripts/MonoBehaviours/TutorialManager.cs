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

        yield return new WaitForSeconds(1);
        if (!Microphone.soundIsActivated) {
            yield return null;
        }

        EndBlowUI.Raise();
        
        yield return new WaitForSeconds(1);

        StartTiltUI.Raise();

        if (Gyro.steeringInput == 0f) {
            yield return null;
        }

        yield return new WaitForSeconds(1);  

        EndTiltUI.Raise();

        yield return new WaitForSeconds(1);  

        SceneManager.LoadScene(tutorialLevelName);
    }
}
