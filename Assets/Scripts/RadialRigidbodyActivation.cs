using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialRigidbodyActivation : MonoBehaviour
{
    public LayerMask activationLayer;
    public float range = 5;
    public float speed = 5;

    private void OnEnable()
    {
        var colliders = Physics.OverlapSphere(transform.position, range, activationLayer);
        foreach(Collider collider in colliders)
        {
            var rb = collider.gameObject.GetComponent<Rigidbody>();
            var distance = Vector3.Distance(transform.position, collider.gameObject.transform.position);
            StartCoroutine(ActivateRigidBody(rb, distance / speed));
            //print(c.gameObject.name);
        }
    }

    IEnumerator ActivateRigidBody(Rigidbody rb, float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.isKinematic = false;
    }
}
