using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //if the checkpoint is activated or not
    public bool activated = false;
    //list all checkpoint objects in the scene
    public static GameObject[] CheckPointsList;

    // Start is called before the first frame update
    void Start()
    {
        CheckPointsList = GameObject.FindGameObjectsWithTag("CheckPoint");
    }


    //active the current checkpoint and disable the rest
    private void ActivateCheckPoint()
    {
        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<CheckPoint>().activated = false;
        }

        activated = true;
    }

    void OnTriggerEnter(Collider other)
    {
        //touch the checkpoint activate
        if (other.tag == "Player")
        {
            ActivateCheckPoint();
        }
    }

    // be called when the player "died"
    public static Vector3 GetActiveCheckPointPosition()
    {
        //no activate checkpoint, return a default position
        Vector3 result = new Vector3(0, 0, 0);
        if (CheckPointsList != null)
            foreach (GameObject cp in CheckPointsList)
                if (cp.GetComponent<CheckPoint>().activated)
                {
                    result = cp.transform.position;
                    break;
                }
        return result;
    }
}
