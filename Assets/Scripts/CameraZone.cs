using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour {

    public Camera playerCam;
    public Camera cam;
    public bool isStill;

    private StillCamScript associatedCamScript;
    private PanningCamera associatedPanScript;

    // Use this for initialization
	void Start ()
    {
        if (isStill) associatedCamScript = cam.GetComponent<StillCamScript>();
        else associatedPanScript = cam.GetComponent<PanningCamera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Entered collider");
        if (collision.gameObject.tag == "Player")
        {
            playerCam.enabled = false;
            if (isStill) associatedCamScript.ActivateCam();
            else associatedPanScript.ActivateCam();
        }
    }
    
    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Left collider");
        if (collision.gameObject.tag == "Player")
        {
            playerCam.enabled = true;
            if (isStill) associatedCamScript.DeactivateCam();
            else associatedPanScript.DeactivateCam();
        }
    }
}
