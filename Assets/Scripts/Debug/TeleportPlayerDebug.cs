using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerDebug : MonoBehaviour {

    // Use this for initialization

    public GameObject[] markers;
    public GameObject player;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Keypad1) && (markers[0]!=null) ) {
            player.transform.position = markers[0].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) && (markers[1] != null))
        {
            player.transform.position = markers[1].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) && (markers[2] != null))
        {
            player.transform.position = markers[2].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) && (markers[3] != null))
        {
            player.transform.position = markers[3].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5) && (markers[4] != null))
        {
            player.transform.position = markers[4].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6) && (markers[5] != null))
        {
            player.transform.position = markers[5].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7) && (markers[6] != null))
        {
            player.transform.position = markers[6].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Keypad8) && (markers[7] != null))
        {
            player.transform.position = markers[7].transform.position;
        }

    }
}
