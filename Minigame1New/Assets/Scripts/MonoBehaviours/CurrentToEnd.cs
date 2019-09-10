using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentToEnd : MonoBehaviour
{
    public GameObject EndPoint; 

    [SerializeField]
    private BoxCollider _boxCollider;

    private Vector3 upperLeft, upperRight, lowerLeft, lowerRight;

    public void Start() {
        EndPoint.transform.localPosition = new Vector3(_boxCollider.size.x * 0.5f, 0, 0);

        var upper = new Vector3(_boxCollider.size.x * 0.5f, 0, _boxCollider.size.z * 0.5f);
        upperLeft = transform.TransformPoint(transform.localPosition + new Vector3(upper.x, 0, -upper.z));
        upperRight = transform.TransformPoint(transform.localPosition + upper);

        lowerLeft = transform.TransformPoint(transform.localPosition - upper);
        lowerRight = transform.TransformPoint(transform.localPosition + new Vector3(-upper.x, 0, upper.z));
    }

    void OnTriggerEnter(Collider collider) {
        collider.transform.root.LookAt(EndPoint.transform.position); 
    } 

    public override void OnDrawGizmos() {

    }
}
