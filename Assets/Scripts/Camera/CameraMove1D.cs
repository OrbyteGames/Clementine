using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class CameraMove1D : MonoBehaviour {
    public GameObject clemen;

    Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        this.transform.SetParent(clemen.transform);
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ
            | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;


    }
	
}
