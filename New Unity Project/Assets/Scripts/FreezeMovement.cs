using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeMovement : MonoBehaviour {

    private bool frozen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (frozen)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            //Finally freeze the body in place so forces like gravity or movement won't affect it
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            //And unfreeze before restoring velocities
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
	}

    public void setFrozen(bool value)
    {
        frozen = value;
    }
}