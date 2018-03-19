using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningCamera : MonoBehaviour {

    private Vector3 startingObjectPos;
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
        startingObjectPos =new Vector3(associatedCam.transform.position.x, associatedCam.transform.position.y, associatedCam.transform.position.z);
        start = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (start) {
            Vector3 playerPos = player.transform.position;
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
                Vector3 targetPos = new Vector3(actualPos.x, actualPos.y, playerPos.z);
                if (!useAxisZ) targetPos = new Vector3(playerPos.x, actualPos.y, actualPos.z);
                float posCoord = actualPos.z;
                if (!useAxisZ) posCoord = actualPos.x;
                if (Mathf.Abs(posCoord - playerCoord) > offset)
                {
                    gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, targetPos, 1.0f * smoothing * Time.deltaTime);
                }
            }
        }
    }

    public void ActivateCam()
    {
        start = true;
        associatedCam.enabled = true;
        Debug.Log("Switching to: " + gameObject.name);
        CameraManager.Instance.SwitchCamera(associatedCam);
    }

    public void DeactivateCam()
    {
        start = false;
        associatedCam.enabled = false;
    }
}
