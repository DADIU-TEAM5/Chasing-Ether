using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoFadeIn : MonoBehaviour
{
    public float speed;
    private Vector3 downMove;
    // Start is called before the first frame update
    void Start()
    {
        downMove = new Vector3(0, speed * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        print(transform.position);
        if (transform.position.y > 150)
        {
            
            transform.Translate(downMove);
        }

    }
}
