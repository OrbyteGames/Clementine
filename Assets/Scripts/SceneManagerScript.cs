using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour {

    public Camera debugCam;
    public CameraManager camManager;
    public Camera camSaved;
    public DebugCam cameraDebug;
    bool debugModeActive;
    int returnCamera;
    private string camName;
    public Camera[] cams;

    public string CamName
    {
        get
        {
            return camName;
        }

        set
        {
            camName = value;
        }
    }

    // Use this for initialization
    void Start () {
        debugModeActive = false;
        for (int i = 0; i < cams.Length; ++i)
        {
            cams[i].enabled = false;
        }
        //cameraOptions.enabled = false;
    }
	


	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P)) {
            if (!debugModeActive)
            {
                camManager.ActivedCamera.enabled = false;
                for (int i = 0; i < cams.Length; ++i)
                {
                    if (cams[i].enabled) {
                        returnCamera = i;
                        camSaved = cams[i];
                        CamName =cams[i].name;
                        cameraDebug.transform.position = cams[i].transform.position;
                        cameraDebug.transform.rotation = cams[i].transform.rotation;
                        cameraDebug.transform.eulerAngles = cams[i].transform.eulerAngles;
                        cameraDebug.tag = cams[i].tag;
                        //cameraDebug.transform.localPosition= cams[i].transform.localPosition;
                        //cameraDebug.transform.localRotation = cams[i].transform.localRotation;
                        //cameraDebug.transform.localScale = cams[i].transform.localScale;
                        //debugCam.transform.position = camManager.ActivedCamera.transform.position;
                        //debugCam.transform.rotation = camManager.ActivedCamera.transform.rotation;
                        //debugCam = camSaved;
                    }
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
