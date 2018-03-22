using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillCamScript : MonoBehaviour {

    public GameObject player;
    public bool enablePlayerLookAt = true;
    private Camera associatedCamera;
    private bool startLooking;

    // Use this for initialization
    void Start () {
        startLooking = false;
        associatedCamera = gameObject.GetComponent<Camera>();
        associatedCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (startLooking && enablePlayerLookAt) {
            associatedCamera.transform.LookAt(player.transform,associatedCamera.transform.up);
            associatedCamera.transform.eulerAngles = new Vector3(associatedCamera.transform.eulerAngles.x, associatedCamera.transform.eulerAngles.y,0);
        }
	}

    public void ActivateCam()
    {
        startLooking = true;
        associatedCamera.enabled = true;
        //CameraManager.Instance.SwitchCamera(associatedCamera);
    }

    public void DeactivateCam()
    {
        startLooking = false;
        associatedCamera.enabled = false;
    }
}
