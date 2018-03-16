using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningCamera : MonoBehaviour {

    private Transform startingTransform;
    private Camera associatedCam;
    // Use this for initialization
    public bool start;
    public float distance;
    public float offset;
    public float smoothing;
    public GameObject player;

    void Start () {
        startingTransform = gameObject.transform;
        associatedCam = gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (start) {
            Vector3 playerPos = player.transform.position;
            Vector3 startingObjectPos = startingTransform.position;
            if (playerPos.x > startingObjectPos.x && playerPos.x < (startingObjectPos.x + distance))
            {
                Vector3 actualPos = gameObject.transform.position;
                Vector3 targetPos = actualPos + new Vector3(playerPos.x ,0.0f,0.0f);
                if (playerPos.x > (actualPos.x + offset))
                {
                    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, 1.0f * smoothing * Time.deltaTime);
                }
                if (playerPos.x < (actualPos.x - offset))
                {
                    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, -1.0f * smoothing * Time.deltaTime);
                }
            }
        }
    }

    public void ActivateCam()
    {
        start = true;
        associatedCam.enabled = true;
        CameraManager.Instance.SwitchCamera(associatedCam);
    }

    public void DeactivateCam()
    {
        start = false;
        associatedCam.enabled = false;
    }
}
