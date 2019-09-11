using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionManager : MonoBehaviour
{

    public IntVariable playerHealth;
    public BoolVariable death;
    public Vector3Variable respawnPoint;
    private Vector3 boatInitLocPos;

    public Vector3 respawnTemp;
    public int healthTemp;

    public GameEvent collisionEvent;
    
    public GameObject TeleportObject;
    public GameObject camLookAtPoint;

    // Start is called before the first frame update
    void Start()
    {
        death.Value = false;

        playerHealth.Value = 5;
        
        respawnPoint.Value = transform.position;

        boatInitLocPos = transform.localPosition;

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "CheckPoint" && collider.tag != "wayPoint")
        {
            Killed();
        }

    }

    public void Killed()
    {
        collisionEvent.Raise();
        GameObject.FindWithTag("collisionSplash").GetComponent<ParticleSystem>().Play();
        playerHealth.Value--;
        death.Value = true;
        /*  
        if (playerHealth.Value > 0)
        {
            TeleportToLastCheckpoint();
        }
        */
        //TeleportToLastCheckpoint();
    }

    public void TeleportToLastCheckpoint() {
        TeleportObject.transform.position = respawnPoint.Value;
        TeleportObject.transform.rotation = Quaternion.identity;
        transform.localPosition = boatInitLocPos;
        transform.localRotation = Quaternion.identity;
        GameObject.FindWithTag("boatSplash").GetComponent<ParticleSystem>().Play();
        TeleportObject.GetComponent<PlayerController>().velocity = TeleportObject.GetComponent<PlayerController>().MinSpeed;
    }

}
