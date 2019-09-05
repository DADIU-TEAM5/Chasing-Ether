using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{

    public GameObject offsetPoint;
    public GameObject player;
    private Vector3 offset;
    private float rotationAngle;
    private Quaternion rotation;
    public float lerpSpeed;
    private Vector3 velocity = Vector3.zero;

   // private Queue<PointInSpace> pointsInSpace = new Queue<PointInSpace>(); //Contains the positions of the target for the last X seconds




    // Start is called before the first frame update
    void Start()
    {
        offset = offsetPoint.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position - (rotation * offset);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, lerpSpeed);

        rotationAngle = player.transform.eulerAngles.y;
        rotation = Quaternion.Euler(0, rotationAngle, 0);

        transform.LookAt(player.transform);

    }
}