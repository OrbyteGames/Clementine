using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackCamera : MonoBehaviour {

    public GameObject Clementine;
    public GameObject[] Markers;
    public Camera previousCam;
    public float activationDist;
    public float duration;
    private float count;
    private Camera thisCam;
    private bool startCount, played;
    private UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl tpuc;
    private Vector3[] posMarkers;

    // Use this for initialization
    void Start()
    {
        count = 0.0f;
        thisCam = gameObject.GetComponent<Camera>();
        tpuc = Clementine.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        startCount = false;
        for (int i = 0; i < Markers.Length; ++i)
        {
            posMarkers[i] = Markers[i].transform.position;

        }
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startCount)
        {
            foreach (Vector3 v in posMarkers)
            {
                if ((Vector3.Distance(Clementine.transform.position, v) < activationDist))
                {
                    previousCam.enabled = false;
                    thisCam.enabled = true;
                    startCount = true;
                    tpuc.DisableMovement();
                }
            }
        }
        else
        {
            if (count < duration)
            {
                count += Time.deltaTime;
            }
            else
            {
                tpuc.EnableMovement();
                thisCam.enabled = false;
                previousCam.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}
