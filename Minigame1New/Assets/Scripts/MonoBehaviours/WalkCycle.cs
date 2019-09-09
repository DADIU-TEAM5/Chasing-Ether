using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkCycle : MonoBehaviour
{
    static Animator anim;
    public BoolVariable throwingAnim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isStopping", false);
         }
        else if(Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isStopping", false);
            anim.SetBool("isThrowing", true);

            throwingAnim.Value = true;
        } /*else if (Input)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isStopping", true);
            anim.SetBool("isThrowing", false);
            throwingAnim.Value = false;
        }
        */
    }

    public void animationEnded()
    {
        anim.SetBool("isWalking", true);
        anim.SetBool("isStopping", false);
        anim.SetBool("isThrowing", false);
    }

}
