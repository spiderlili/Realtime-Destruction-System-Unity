using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectOnCollision : MonoBehaviour
{
    public float activationForce = 20; //compare against each rigid body - trigger the object if forces exceed this 
    public GameObject[] objectsToActivate;

    private void OnCollisionEnter(Collision collision)
    {
        //compare the relative velocity of this object with the activation force
        if(collision.relativeVelocity.sqrMagnitude > activationForce)
        {
            foreach (GameObject objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(true);
            }            
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.relativeVelocity.sqrMagnitude > activationForce)
        {
            foreach (GameObject objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}
