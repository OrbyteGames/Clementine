using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour
{

    public Camera cam;
    public bool isStill;

    private CameraRotation associatedCamScript;

    // Use this for initialization
    void Start()
    {
        associatedCamScript = cam.GetComponent<CameraRotation>();
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
            associatedCamScript.ActivateCam();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //playerCam.enabled = true;
            associatedCamScript.DeactivateCam();
        }
    }
}