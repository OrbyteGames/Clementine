using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour {

    public Camera debugCam;
    public CameraManager camManager;
    bool debugModeActive;
    public Camera[] cams;
	// Use this for initialization
	void Start () {
        debugModeActive = false;
        for (int i = 0; i < cams.Length; ++i)
        {
            cams[i].enabled = false;
        }
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
