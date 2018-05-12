using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicTrigger : MonoBehaviour {

    public FlashBackFamilyWindow fbfw;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 2) {
            fbfw.StartScene();
        }
	}
}
