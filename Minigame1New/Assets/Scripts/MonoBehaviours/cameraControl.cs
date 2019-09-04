using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    private float rotationAngle;
    private Quaternion rotation;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.position - transform.position;;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position - (rotation * offset);

        rotationAngle = player.transform.eulerAngles.y;
        rotation = Quaternion.Euler(0, rotationAngle, 0);

        transform.LookAt(player.transform);

    }
}
