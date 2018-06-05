using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour
{

    public Camera cam;
    public bool isStill;

    private CameraRotation associatedRotationCamScript;
 
    // Use this for initialization
    void Start()
    {
        associatedRotationCamScript = cam.GetComponent<CameraRotation>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //playerCam.enabled = false;
            cam.enabled = true;
            cam.GetComponent<AudioListener>().enabled = true;
            if (associatedRotationCamScript) associatedRotationCamScript.ActivateCam();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //playerCam.enabled = true;
            cam.enabled = false;
            cam.GetComponent<AudioListener>().enabled = true;
            if (associatedRotationCamScript) associatedRotationCamScript.DeactivateCam();
        }
    }
}