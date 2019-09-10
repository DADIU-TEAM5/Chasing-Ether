﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionManager : MonoBehaviour
{

    public IntVariable playerHealth;
    public Vector3Variable respawnPoint;

    public Vector3 respawnTemp;
    public int healthTemp;

    public GameEvent collisionEvent;
    
    public GameObject TeleportObject;

    // Start is called before the first frame update
    void Start()
    {

        playerHealth.Value = 5;
        
        respawnPoint.Value = transform.position;
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
        playerHealth.Value--;
        /*  
        if (playerHealth.Value > 0)
        {
            TeleportToLastCheckpoint();
        }
        */
        TeleportToLastCheckpoint();
    }

    private void TeleportToLastCheckpoint() {
        TeleportObject.transform.position = respawnPoint.Value;
        TeleportObject.transform.rotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        TeleportObject.GetComponent<PlayerController>().velocity = TeleportObject.GetComponent<PlayerController>().MinSpeed;
    }

}
