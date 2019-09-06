using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionManager : MonoBehaviour
{

    public IntVariable playerHealth;
    public Vector3Variable respawnPoint;

    public Vector3 respawnTemp;
    public int healthTemp;
    private GameObject thisRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth.Value = 5;

        thisRigidbody = GameObject.FindGameObjectWithTag("Player");

        Vector3 temp = new Vector3(thisRigidbody.transform.position.x, thisRigidbody.transform.position.y, thisRigidbody.transform.position.z);
        respawnPoint.Value = temp;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "CheckPoint")
        {
            //print("Hit!");
            Killed();

        }
    }

    public void Killed()
    {
        playerHealth.Value--;

        if (playerHealth.Value > 0)
        {
            //print("respawn location:  " + respawnPoint.Value);
            //print("position:   " + gameObject.transform.position);
            thisRigidbody.transform.position.Set(respawnPoint.Value.x, respawnPoint.Value.y, respawnPoint.Value.z);
            thisRigidbody.transform.position = respawnPoint.Value;

        }

       // print(playerHealth.Value);
    }

}
