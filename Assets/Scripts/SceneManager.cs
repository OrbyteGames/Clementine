using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public Camera debugCam;
    public CameraManager camManager;
    bool debugModeActive;
	// Use this for initialization
	void Start () {
        debugModeActive = false;
	}
	


	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.P)) {
            if (!debugModeActive)
            {
                debugCam.transform.position = camManager.ActivedCamera.transform.position;
                debugCam.transform.rotation = camManager.ActivedCamera.transform.rotation;
                camManager.ActivedCamera.enabled = false;
                debugCam.enabled = true;
            }
            else
            {
                debugCam.enabled = false;
                camManager.ActivedCamera.enabled = true;
            }
        }
    }
}
