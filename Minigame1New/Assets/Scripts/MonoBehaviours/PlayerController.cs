using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool phoneControl;
    public float forwardVel;
    public float rotateVel;
    public float boostFactor;
    private float boostInput;
    private float mvFactor;
    private float volume;
    private CharacterController pController;
    private Vector3 forwardMove;

    // Start is called before the first frame update
    void Start()
    {
        pController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (phoneControl == true)
        {
            volume = GetComponent<MicrophoneInputv2>().volume;
            Debug.Log(volume);
            forwardVel = volume;
        }

        Movement();
    }

    public void Movement()
    {
        mvFactor = 1f;

        if (Input.GetButton("Jump"))
        {
            boost();
        }

        //Debug.Log(forwardVel);

        forwardMove = new Vector3(0, 0, forwardVel + mvFactor * Time.deltaTime);

        forwardMove = transform.TransformDirection(forwardMove);
        

        if (phoneControl == true)
        {
            transform.Rotate(Vector3.up * GetComponent<GyroController>().rotation.y * rotateVel);
        }
        else
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotateVel);

            // var rotation = transform.eulerAngles;
            // rotation.z = Mathf.Clamp(transform.eulerAngles.z, -10, 10);

            // transform.eulerAngles = rotation;
        }

        pController.Move(forwardMove);

    }


    public float boost()
    {
        // Get input from keys/controller
        boostInput = Input.GetAxis("Jump");

        // Set the factor for the input
        mvFactor = boostFactor * boostInput;

        return mvFactor;
               
    }

}
