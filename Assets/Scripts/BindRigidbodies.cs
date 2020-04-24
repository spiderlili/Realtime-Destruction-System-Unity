using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindRigidbodies : MonoBehaviour
{
    public LayerMask rigidbodyLayer;
    public float breakForce = Mathf.Infinity;
    public float breakTorque = Mathf.Infinity;

    private void Awake()
    {
        //check for overlapping objects
        var collidersInRadius = Physics.OverlapSphere(transform.position, transform.localScale.x / 2, rigidbodyLayer.value);
        for(int i = 0; i < collidersInRadius.Length - 1; i++)
        {
            FixedJoint joint = collidersInRadius[i].gameObject.AddComponent<FixedJoint>(); //add a fixed joint to the 1st object in the array

            //set the connected rigidbody of the dynamically generated joint to the rigidbody of the next collider in the list
            joint.connectedBody = collidersInRadius[i + 1].gameObject.GetComponent<Rigidbody>();
            joint.breakForce = breakForce;
            joint.breakTorque = breakTorque;
        }
        Destroy(gameObject);
    }

}
