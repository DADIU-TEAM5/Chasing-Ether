using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionManager : MonoBehaviour
{

    public IntVariable playerHealth;
    public BoolVariable death;
    public Vector3Variable respawnPoint;
    public Vector3Variable respawnPointCam;

    public Vector3 respawnTemp;
    public int healthTemp;

    public GameEvent collisionEvent;
    
    public GameObject TeleportObject;
    public GameObject camLookAtPoint;

    // Start is called before the first frame update
    void Start()
    {

        playerHealth.Value = 5;
        
        respawnPoint.Value = transform.position;
        respawnPointCam.Value = camLookAtPoint.transform.position;
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
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        GameObject.FindWithTag("boatSplash").GetComponent<ParticleSystem>().Play();
        TeleportObject.GetComponent<PlayerController>().velocity = TeleportObject.GetComponent<PlayerController>().MinSpeed;

        camLookAtPoint.transform.position = respawnPoint.Value + camLookAtPoint.transform.localPosition;
        camLookAtPoint.transform.rotation = Quaternion.identity;
    }

}
