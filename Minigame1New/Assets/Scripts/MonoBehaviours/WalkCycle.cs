using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkCycle : MonoBehaviour
{
    static Animator anim;
    public BoolVariable walkingAnim;
    public BoolVariable throwAnim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkingAnim.Value == true)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isThrowing", false);
        }

        if (throwAnim.Value == true)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isThrowing", true);

            walkingAnim.Value = false;
        }

        if (walkingAnim.Value == false && throwAnim.Value == false)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isThrowing", false);
        }
   
    }

    public void ThrowAnimEnd()
    {
        walkingAnim.Value = true;
        throwAnim.Value = false;
    }

}
