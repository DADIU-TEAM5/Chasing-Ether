using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool phoneControls;
    

    public Transform vectorInFrontOfBoat;

    public float MaxSpeed;
    public float MinSpeed;
    public float SpeedDecayRate;
    public float RotationSpeed;
    public float BoostAccelerationRate;
    private float boostInput;

    float velocity ;

    public float maxRotationAngle = 45;
    
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

        if (phoneControls)
        {



            currentRotation = Input.gyro.rotationRate.y;

            
                print(currentRotation);

                if (currentRotation < 0)
                {
                    currentRotation = -1 * Mathf.Clamp01(Mathf.Abs(currentRotation));
                }
                else
                {
                    currentRotation = Mathf.Clamp01(Mathf.Abs(currentRotation));
                }
            

            print(currentRotation);

        }
        else
        {
            currentRotation = Input.GetAxis("Horizontal");
        }
        

        Movement();
    }

    public void Movement()
    {

        

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

                boatGraphics.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -20 * currentRotation));

                if(Vector3.Angle(vectorInFrontOfBoat.position - transform.position, Vector3.forward) >= maxRotationAngle)
                {
                    transform.Rotate(Vector3.up * -currentRotation * RotationSpeed * Time.deltaTime);

                    
                }









        // var rotation = transform.eulerAngles;
        // rotation.z = Mathf.Clamp(transform.eulerAngles.z, -10, 10);

        // transform.eulerAngles = rotation;

        fan.Rotate(Vector3.forward, -10* velocity * Time.deltaTime);
        transform.Translate(Vector3.forward*velocity *Time.deltaTime);

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

}
