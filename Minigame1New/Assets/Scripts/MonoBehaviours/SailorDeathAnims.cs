using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            GameObject.FindWithTag("boatSplash").GetComponent<ParticleSystem>().Stop();
        }

    }

    public void HideSailor()
    {
            anim.enabled = false;
            death.Value = false;

            if (playerHealth.Value == 0)
            {
                SceneManager.LoadScene("GameOver");
            } else
            {
                GetComponentInParent<CollisionManager>().TeleportToLastCheckpoint();
            }
            gameObject.SetActive(false);
    }
}
