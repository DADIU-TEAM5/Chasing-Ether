using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float speed;
    public bool isPatroling;
    public Transform[] wayPoints;
    private int point = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPatroling && wayPoints.Length != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[point].position, speed*Time.deltaTime);
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        print("Collision");
        if (other.tag == "wayPoint")
        {
            point++;
            point = point % wayPoints.Length;
            print(point);
        }
    }
}
