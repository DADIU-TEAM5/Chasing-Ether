using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentToEnd : MonoBehaviour
{
    [SerializeField]
    private BoxCollider _boxCollider;
    void OnTriggerEnter(Collider collider) {
        var currentForwardToWorld = transform.TransformDirection(transform.forward);
        collider.transform.root.LookAt(collider.transform.root.position + currentForwardToWorld); 
    } 
}
