using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{



    public FloatVariable gyroY;

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

    float velocity ;

    private float volume;
    private CharacterController pController;

    public Transform fan;
    public GameObject boatGraphics;

    float currentRotation;

    //public MicrophoneInput microPhoneInput;
    public BoolVariable microPhoneInput;

    // Start is called before the first frame update
    void Start()
    {
        velocity = MinSpeed;
        pController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (enablePhoneControls)
        {
            
            currentRotation = Input.gyro.attitude.x;
            
            if (Mathf.Abs(currentRotation) > minTiltAngleThreshold)
            {
                currentRotation = currentRotation * -1;
            }
            else
            {
                currentRotation = 0;
            }


                /* DELETEABLE?
                if (Mathf.Abs(currentRotation) > minTiltAngleThreshold)
                {

                    print(currentRotation);

                    if (currentRotation < 0)
                    {
                        currentRotation = -1 * Mathf.Lerp(minTiltAngleThreshold, maxTiltAngleThreshold, Mathf.Abs(currentRotation));
                    }
                    else
                    {
                        currentRotation = Mathf.Lerp(minTiltAngleThreshold, maxTiltAngleThreshold, Mathf.Abs(currentRotation));
                    }

                }
                else
                {
                    currentRotation = 0;
                }
                print(currentRotation);
                */
               
        }
        else
        {
            currentRotation = Input.GetAxis("Horizontal");
            currentRotation *= 0.3f;
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

        if (Input.GetButton("Jump") || microPhoneInput.Value)
        {
            boost();
        }

        //Debug.Log(forwardVel);

        //forwardMove = transform.TransformDirection(forwardMove);
        
        //print(microPhoneInput.soundIsActivated);

            
        transform.Rotate(Vector3.up * currentRotation * RotationSpeed * Time.deltaTime);

        boatGraphics.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -RotationSpeed * currentRotation));

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
        // Set the factor for the input
        velocity += BoostAccelerationRate*Time.deltaTime;

        if (velocity > MaxSpeed)
            velocity = MaxSpeed;

        return BoostAccelerationRate;
               
    }

}
