using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectOnCollisionNoGCAlloc : MonoBehaviour
{
    public float activationForce = 20; //compare against each rigid body - trigger the object if forces exceed this 
    public GameObject[] objectsToActivate;

    bool go = true;
    float velocity;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if(rb == null || objectsToActivate == null)
        {
            go = false;
        }
    }

    private void FixedUpdate()
    {
        if (go)
        {
            if (!rb.isKinematic)
            {
                if (!rb.IsSleeping())
                {
                    var v = Mathf.Abs(rb.velocity.sqrMagnitude);
                    if ((v - velocity) > activationForce)
                    {
                        foreach (GameObject objectToActivate in objectsToActivate)
                        {
                            objectToActivate.SetActive(true);
                        }
                        velocity = v;
                    }
                }
            }
        }
    }
}
