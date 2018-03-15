using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour {

    Rigidbody rb;
    public GameObject player;

    public float DistanceToBox;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Define variables
        DistanceToBox = transform.position.z-player.transform.position.z;

        if (-0.7f<DistanceToBox&& DistanceToBox < 0f && Input.GetKey("q"))
        {
            rb.AddForce(20f, 0, 0);
        }
        else rb.velocity.Set(0f, 0, 0);
    }
}
//Player.transform.forward