using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMenuScript : MonoBehaviour
{


    public float rotationSpeed = 0.5f;
    public float heightMinimum = 40;
    public float heightMaximum = 50;

    float currentRotationSpeed = 0;
    public GameObject cloud;

    // Start is called before the first frame update
    void Start()
    {
        float randomHeight = Random.Range(heightMinimum, heightMaximum);
        cloud.transform.position = new Vector3(transform.position.x, transform.position.y + randomHeight, transform.position.z + 500);

        DefineRotationSpeed();
        transform.Rotate(Vector3.up, Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, currentRotationSpeed, 0 * Time.deltaTime);
    }

    public void DefineRotationSpeed()
    {
        currentRotationSpeed = Random.Range(-rotationSpeed, rotationSpeed);

        if (currentRotationSpeed < 0.01f && currentRotationSpeed > -0.01f)
        {
            DefineRotationSpeed();
        }
    }
}
