using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool phoneControls;

    public Transform vectorInFrontOfBoat;

    public float forwardVel;
    public float rotateVel;
    public float boostFactor;
    private float boostInput;

    public float maxRotation = 45;
    private float mvFactor;
    private float volume;
    private CharacterController pController;
    private Vector3 forwardMove;

    public GameObject boatGraphics;

    float currentRotation;

    public GyroController gyroController;
    public MicrophoneInput microPhoneInput;

    // Start is called before the first frame update
    void Start()
    {
        pController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (phoneControl == true)
        {
            volume = GetComponent<MicrophoneInputv2>().volume;
            Debug.Log(volume);
            forwardVel = volume;
        }
        */
        
        currentRotation = Input.GetAxis("Horizontal");

        Movement();
    }

    public void Movement()
    {
        mvFactor = 1f;


        if (Input.GetButton("Jump") || microPhoneInput.soundIsActivated)
        {
            boost();
        }

        //Debug.Log(forwardVel);

        forwardMove = new Vector3(0, 0, forwardVel + mvFactor * Time.deltaTime);

        //forwardMove = transform.TransformDirection(forwardMove);


        //print(microPhoneInput.soundIsActivated);

        
        
        

            if (phoneControls)
            {
                transform.Rotate(Vector3.up * gyroController.rotation.y * rotateVel);
                boatGraphics.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -20 * gyroController.rotation.y));

            if (Vector3.Angle(vectorInFrontOfBoat.position - transform.position, Vector3.forward) >= maxRotation)
            {
                transform.Rotate(Vector3.up * -gyroController.rotation.y * rotateVel * Time.deltaTime);


            }

        }
            else
            {
                transform.Rotate(Vector3.up * currentRotation * rotateVel * Time.deltaTime);

                boatGraphics.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -20 * currentRotation));

                if(Vector3.Angle(vectorInFrontOfBoat.position - transform.position, Vector3.forward) >= maxRotation)
                {
                    transform.Rotate(Vector3.up * -currentRotation * rotateVel * Time.deltaTime);

                    
                }

            }
            
            

        
        
        

        // var rotation = transform.eulerAngles;
        // rotation.z = Mathf.Clamp(transform.eulerAngles.z, -10, 10);

        // transform.eulerAngles = rotation;


        transform.Translate(forwardMove);

    }


    public float boost()
    {
        // Get input from keys/controller
        //boostInput = Input.GetAxis("Jump");

        
        // Set the factor for the input
        mvFactor = boostFactor ;

        return mvFactor;
               
    }

}
