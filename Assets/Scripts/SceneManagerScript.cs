using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour {

    public Camera debugCam;
    public CameraManager camManager;
    public Camera camSaved;
    bool debugModeActive;
    int returnCamera;
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
        if (Input.GetKeyDown(KeyCode.P)) {
            if (!debugModeActive)
            {
                debugCam.transform.position = camManager.ActivedCamera.transform.position;
                debugCam.transform.rotation = camManager.ActivedCamera.transform.rotation;
                //camManager.ActivedCamera.enabled = false;
                for (int i = 0; i < cams.Length; ++i)
                {
                    if (cams[i].enabled) { returnCamera = i; camSaved = cams[i]; }
                    cams[i].enabled = false;
                }
                debugCam.enabled = true;
                debugModeActive = true;
            }
            else
            {
                cams[returnCamera].enabled = true;
                cams[returnCamera] = camSaved;
                debugCam.enabled = false;
                camManager.ActivedCamera.enabled = true;
                debugModeActive = false;
            }
        }
    }
}
