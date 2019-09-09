using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    float boatTurn =0;

   // public GameObject testCube;

    [Header("Boat Variables")]

    public float MaxSpeed;
    public float MinSpeed;
    public float SpeedDecayRate;
    public float RotationSpeed;
    public float BoostAccelerationRate;
    public float maxRotationAngle = 45;


    [Header("Phone Controls")]

    public bool enablePhoneControls;
    public float minTiltAngleThreshold = 1;
    //public float maxTiltAngleThreshold = 5;

    private float boostInput;

    [Header("Set up")]
    public Transform vectorInFrontOfBoat;

    public float velocity ;

    
    
    private float volume;
    private CharacterController pController;


    public Transform fan;
    public GameObject boatGraphics;

    float currentRotation;

    public GyroController gyroController;
    public MicrophoneInput microPhoneInput;

    // Start is called before the first frame update
    void Start()
    {
        velocity = MinSpeed;
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

        if (enablePhoneControls)
        {

            currentRotation = gyroController.steeringInput;
            

            /*
            if (Mathf.Abs(currentRotation) > minTiltAngleThreshold)
            {
                currentRotation = currentRotation * -1;
            }
            else
            {
                currentRotation = 0;
            }


              */ 
               
        }
        else
        {
            currentRotation = Input.GetAxis("Horizontal");
            
        }
        

        Movement();
    }

    public void Movement()
    {

        if (Mathf.Abs(boatTurn) < 1)
        {
            boatTurn += Time.deltaTime *currentRotation*2;


        }


        if (velocity > MinSpeed)
        {
            velocity -= SpeedDecayRate * Time.deltaTime;
            if (velocity < MinSpeed)
                velocity = MinSpeed;
        }

        

        if (Input.GetButton("Jump") || microPhoneInput.soundIsActivated)
        {
            boost();
        }

        //Debug.Log(forwardVel);

        

        //forwardMove = transform.TransformDirection(forwardMove);


        //print(microPhoneInput.soundIsActivated);

        
        
        

            
                transform.Rotate(Vector3.up * currentRotation * RotationSpeed * Time.deltaTime);

                boatGraphics.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -35 * boatTurn));

                if(Vector3.Angle(vectorInFrontOfBoat.position - transform.position, Vector3.forward) >= maxRotationAngle)
                {
                    transform.Rotate(Vector3.up * -currentRotation * RotationSpeed * Time.deltaTime);

                    
                }









        // var rotation = transform.eulerAngles;
        // rotation.z = Mathf.Clamp(transform.eulerAngles.z, -10, 10);

        // transform.eulerAngles = rotation;

        fan.Rotate(Vector3.forward, -10* velocity * Time.deltaTime);
        transform.Translate(Vector3.forward*velocity *Time.deltaTime);


        if(boatTurn < 0)
        {
            boatTurn += Time.deltaTime;
            if (boatTurn > 0)
                boatTurn = 0;
        }
        else if(boatTurn> 0)
        {
            boatTurn -= Time.deltaTime;
            if (boatTurn < 0)
                boatTurn = 0;
        }


        //print(boatTurn);
    }


    public float boost()
    {
        // Get input from keys/controller
        //boostInput = Input.GetAxis("Jump");


        // Set the factor for the input
        velocity += BoostAccelerationRate*Time.deltaTime;

        if (velocity > MaxSpeed)
            velocity = MaxSpeed;

        return BoostAccelerationRate;
               
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

}
