using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentToCenter : MonoBehaviour
{
    public BoxCollider _boxCollider;

    private Vector3 _closestPoint;

    public GameEvent EnterCurrent;
    public GameEvent ExitCurrent;

    public float TimeToRotate;

    private Transform _transform;

    void Update() {

    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider collision) {
        _closestPoint = _boxCollider.ClosestPointOnBounds(collision.gameObject.transform.position);
        StartCoroutine(MoveToInner(collision.transform.root, _closestPoint));
        EnterCurrent.Raise();
    }

    void OnTriggerExit(Collider collider) {
        ExitCurrent.Raise();
    }

    IEnumerator MoveToInner(Transform otherTransform, Vector3 lookAt) {
        Debug.Log("OYOO");
        var start = otherTransform.rotation;
        var end = Vector3.Normalize(lookAt - otherTransform.position); 

        var quaternionLookat = Quaternion.LookRotation(end, transform.up);

        //for (float t = 0f; t <= TimeToRotate; t += Time.deltaTime) {
        //    Debug.Log(t);
        //    otherTransform.rotation = Quaternion.Lerp(start, quaternionLookat, t / TimeToRotate);
        //    yield return new WaitForSeconds(Time.deltaTime);
        //}

        otherTransform.rotation = Quaternion.Lerp(start, quaternionLookat, 1f);
        yield break;
    }
}
