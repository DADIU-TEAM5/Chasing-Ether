using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentToEnd : MonoBehaviour
{
    [SerializeField]
    private BoxCollider _boxCollider;
    void OnTriggerEnter(Collider collider) {
        collider.transform.root.rotation = transform.root.rotation; 
        Debug.Log("WHASHDJAHSDKJ");
    } 
}
