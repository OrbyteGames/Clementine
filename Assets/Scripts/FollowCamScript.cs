using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamScript : MonoBehaviour {

    public GameObject player;
    public float offsetX = 5.0f;
    public float offsetZ = 5.0f;
    public float smoothing = 10.0f;
    private Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        offset = gameObject.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 pos = gameObject.transform.position;
        Vector3 targetPos = playerPos+offset;
        if (Mathf.Abs((pos-offset).x- playerPos.x) > offsetX)
        {
            //targetPos.x +=  offset.x;
            gameObject.transform.position = Vector3.Lerp(pos, targetPos, smoothing * Time.deltaTime);
        }
        if (Mathf.Abs((pos - offset).z - playerPos.z) > offsetZ)
        {
            //targetPos.z +=  offset.z;
            gameObject.transform.position = Vector3.Lerp(pos, targetPos, smoothing * Time.deltaTime);

        }

    }
}
