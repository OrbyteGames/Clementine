using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCamera : MonoBehaviour {

    public GameObject Clementine, Marker1,Marker2;
    public Camera previousCam;
    public float activationDist;
    public float duration;
    public float meowSoundTimeStamp;
    private float count;
    private Camera thisCam;
    private AudioSource meowSound;
    private Vector3 groundPos;
    private bool startCount, played;
    private UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl tpuc;
    private Vector3 posMarker1, posMarker2;

    // Use this for initialization
    void Start () {
        count = 0.0f;
        thisCam = gameObject.GetComponent<Camera>();
        tpuc = Clementine.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        meowSound = gameObject.GetComponent<AudioSource>();
        startCount = false;
        posMarker1 = Marker1.transform.position;
        posMarker2 = Marker2.transform.position;
        played = false;
	}
	
	// Update is called once per frame
	void Update () {

        if ((Vector3.Distance( Clementine.transform.position, posMarker1) < activationDist) ||
            (Vector3.Distance( Clementine.transform.position, posMarker2) < activationDist))
        {
            previousCam.enabled = false;
            thisCam.enabled = true;
            startCount = true;
            tpuc.DisableMovement();
        }
        if (startCount) {
            if (count < duration)
            {
                count += Time.deltaTime;
                if (count > meowSoundTimeStamp && !played)
                {
                    meowSound.Play();
                    played = true;
                }
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
