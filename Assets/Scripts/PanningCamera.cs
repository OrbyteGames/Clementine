using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningCamera : MonoBehaviour {

    private Transform startingTransform;
    private Camera associatedCam;
    // Use this for initialization
    private bool start;
    public float distance;
    public float offset;
    public float smoothing;
    public GameObject player;
    public bool useAxisZ;

    void Start () {
        associatedCam = gameObject.GetComponent<Camera>();
        startingTransform = associatedCam.transform;

        start = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (start) {
            Vector3 playerPos = player.transform.position;
            Vector3 startingObjectPos = startingTransform.position;
            float playerCoord = playerPos.z;
            float camCoord = startingObjectPos.z;
            if (!useAxisZ)
            {
                playerCoord = playerPos.x;
                camCoord = startingObjectPos.x;
            }
            if (playerCoord > camCoord && playerCoord < (camCoord + distance))
            {
                Vector3 actualPos = gameObject.transform.position;
                Vector3 targetPos = actualPos + new Vector3(0.0f, 0.0f, playerPos.z);
                if (!useAxisZ) targetPos = new Vector3(playerPos.x, 0.0f, 0.0f);
                float posCoord = actualPos.z;
                if (!useAxisZ) posCoord = actualPos.x;
                if (Mathf.Abs(posCoord - playerCoord) < 0.1)
                {
                    if (useAxisZ) gameObject.transform.position = new Vector3(actualPos.x, actualPos.y, playerPos.z);
                    else gameObject.transform.position = new Vector3(playerPos.x,actualPos.y, actualPos.z);
                }
/*else
                {
                    if (playerCoord > (posCoord + offset)) gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, 1.0f * smoothing * Time.deltaTime);
                    if (playerCoord < (posCoord - offset)) gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, 1.0f * smoothing * Time.deltaTime);
                }*/


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
