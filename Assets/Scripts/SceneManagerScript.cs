using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour {

    public Camera debugCam;
    public CameraManager camManager;
    public Camera camSaved;
    //public DebugCam cameraOptions = new DebugCam();
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
                    if (cams[i].enabled) { returnCamera = i; camSaved = cams[i]; CamName =cams[i].name; }
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
        if(Input.GetKeyDown(KeyCode.I)&& debugCam.enabled)
        {
            debugCam.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.I) && !debugCam.enabled)
        {
            debugCam.enabled = true;
        }
    }
}
