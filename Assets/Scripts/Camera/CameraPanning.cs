using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanning : MonoBehaviour {

    public GameObject clement;
    Camera cam;

	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        cam.transform.LookAt(clement.transform);	
	}
}
