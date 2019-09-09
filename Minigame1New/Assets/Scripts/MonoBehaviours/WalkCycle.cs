using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkCycle : MonoBehaviour
{
    static Animator anim;
    public BoolVariable walkingAnim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isStopping", false);

            walkingAnim.Value = true;
        }
        else if(Input.GetButton("Fire1"))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isStopping", false);
            anim.SetBool("isThrowing", true);

            walkingAnim.Value = false;
        } else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isStopping", true);
            anim.SetBool("isThrowing", false);


            walkingAnim.Value = true;
        }
   
    }

    public void throwingAnimEnd()
    {
        anim.SetBool("isWalking", true);
        anim.SetBool("isStopping", false);
        anim.SetBool("isThrowing", false);

        walkingAnim.Value = true;
    }

}
