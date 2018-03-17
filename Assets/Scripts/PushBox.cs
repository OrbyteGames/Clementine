using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//NOT USING IT!

public class PushBox : MonoBehaviour {

    Rigidbody rb;
    public GameObject player;
    public Transform target;
    public float DistanceToBox;
    //float step = 1 * Time.deltaTime;
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

        if (Input.GetKeyDown("q"))
        {
            Debug.Log("q is pressed");
           // transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            rb.AddForce(-4f, 0, 0);
            
        }
       if (Input.GetKeyUp("q"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
//Player.transform.forward