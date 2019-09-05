using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : MonoBehaviour
{
    GameObject thisRigidbody;
    private float x, y, z;
    public int speed=1;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody =  GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        controlPlaybykeyboard();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "testEnemy")
        {
            thisRigidbody.transform.position = CheckPoint.GetActiveCheckPointPosition();
        }
    }

    void controlPlaybykeyboard()
    {
        x = thisRigidbody.transform.position.x;
        y = thisRigidbody.transform.position.y;
        z = thisRigidbody.transform.position.z;
        float move = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))

        {
            thisRigidbody.transform.position = new Vector3(x, y, z + move);
        }
        if (Input.GetKey(KeyCode.A))

        {
            thisRigidbody.transform.position = new Vector3(x - move, y, z);
        }
        if (Input.GetKey(KeyCode.S))

        {
            thisRigidbody.transform.position = new Vector3(x, y, z - move);
        }
        if (Input.GetKey(KeyCode.D))

        {
            thisRigidbody.transform.position = new Vector3(x + move, y, z);
        }
    }
 }
