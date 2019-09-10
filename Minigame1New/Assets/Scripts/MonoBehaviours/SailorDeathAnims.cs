using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailorDeathAnims : MonoBehaviour
{

    private Animator anim;
    public IntVariable playerHealth;
    public BoolVariable death;
    public int sailorNum;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(sailorNum == playerHealth.Value)
        {
            anim.enabled = true;
            anim.SetInteger("health", playerHealth.Value);
            anim.SetBool("sailorDeath", death.Value);
        }

    }

    public void HideSailor()
    {
            gameObject.SetActive(false);
            anim.enabled = false;
            GetComponentInParent<CollisionManager>().TeleportToLastCheckpoint();
            death.Value = false; 
    }
}
