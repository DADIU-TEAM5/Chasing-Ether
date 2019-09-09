using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemBehaviour : MonoBehaviour
{

    public GameObject finishLineObj;
    public GameObject playerObj;
    private Vector3 finishLinePos;
    private Vector3 bossStartPos;
    private Vector3 playerStartPos;
    private Vector3 playerCurPos;
    private float playerBossDist;
    public float lerpSpeed = 2f;
    private Vector3 tempSpeed = Vector3.zero;
    public BoolVariable throwingAnim;

    // Start is called before the first frame update
    void Start()
    {
        bossStartPos = transform.position;
        playerStartPos = playerObj.transform.position;
        finishLinePos = new Vector3(finishLineObj.transform.position.x, bossStartPos.y, finishLineObj.transform.position.z);
        playerBossDist = Mathf.Abs(bossStartPos.z - playerStartPos.z);
    }

    // Update is called once per frame
    void Update()
    {

        if(throwingAnim.Value != true)
        {
            playerCurPos = playerObj.transform.position;

            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(bossStartPos.x, bossStartPos.y, playerCurPos.z + playerBossDist), ref tempSpeed, lerpSpeed);
        }
    
       
    }
}
