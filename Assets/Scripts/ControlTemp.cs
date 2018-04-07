using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTemp : MonoBehaviour {

    public float speed = 3f;
	
	// Update is called once per frame
	void Update ()
    {
        
        float postX = Input.GetAxis("Horizontal");
        float PosY = Input.GetAxis("Vertical");

        transform.Translate(postX*speed*Time.deltaTime, 0f, PosY*speed*Time.deltaTime);
     
	}
}
