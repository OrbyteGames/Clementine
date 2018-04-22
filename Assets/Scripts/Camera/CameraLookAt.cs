using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

    public GameObject player;
    private Camera cam;
	// Use this for initialization
	void Start () {
        cam = gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        cam.transform.LookAt(player.transform.position);
	}
}
