using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTrigger : MonoBehaviour
{
    public GameObject key;

    public void OnTriggerEnter(Collider other)
    {

        //*note: the key needs to have rigidbody component
        //and the lock which this script is attached must have a collider with isTriggered checked.

        if(other.gameObject == key)
        {
            print("COllided with the key");
        }
    }
}
