using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {


    public bool enableX, enableY, enableZ;

    public float rotationXRangeMax;
    public float rotationXRangeMin;

    public float rotationYRangeMax;
    public float rotationYRangeMin;

    public float rotationZRangeMax;
    public float rotationZRangeMin;

    public GameObject target;

    private Camera cam;
    private AudioListener audioList;
    private bool start;
    // Use this for initialization
    void Start() {
        start = false;
        cam = gameObject.GetComponent<Camera>();
        audioList = gameObject.GetComponent<AudioListener>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if (start)
        {
            Vector3 relativePos = target.transform.position - transform.position;
            Quaternion q = Quaternion.LookRotation(relativePos);
            Vector3 rot = q.eulerAngles;
            if (enableX)
            {
                if (rot.x < rotationXRangeMin) rot.x = rotationXRangeMin;
                if (rot.x > rotationXRangeMax) rot.x = rotationXRangeMax;

            }
            if (enableY)
            {
                if (rot.y < rotationYRangeMin) rot.y = rotationYRangeMin;
                if (rot.y > rotationYRangeMax) rot.y = rotationYRangeMax;
            }
            if (enableZ)
            {
                if (rot.z < rotationZRangeMin) rot.z = rotationZRangeMin;
                if (rot.z > rotationZRangeMax) rot.z = rotationZRangeMax;
            }
            cam.transform.rotation = Quaternion.Euler(rot);
        }
    }

    public void ActivateCam()
    {
        start = true;
        if(!cam.enabled) cam.enabled = true;
        audioList.enabled = true;
    }

    public void DeactivateCam()
    {
        start = false;
        if (cam.enabled) cam.enabled = false;
        audioList.enabled = false;
    }
}
