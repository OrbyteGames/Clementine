using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCamera : MonoBehaviour {

    public GameObject Clementine, Marker1;
    public Camera previousCam;
    public float activationDist;
    public float duration;
    public float meowSoundTimeStamp;
    private float count;
    private Camera thisCam;
    private AudioSource meowSound;
    private bool startCount, played;
    private UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl tpuc;

    // Use this for initialization
    void Start () {
        count = 0.0f;
        thisCam = gameObject.GetComponent<Camera>();
        //tpuc = Clementine.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        meowSound = gameObject.GetComponent<AudioSource>();
        startCount = false;

        played = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!startCount)
        {           
            if ((Vector3.Distance(Clementine.transform.position, Marker1.transform.position) < activationDist))
            {
                previousCam.enabled = false;
                thisCam.enabled = true;
                startCount = true;
                //tpuc.DisableMovement();                   
            }
        }
        else {
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
                //tpuc.EnableMovement();
                thisCam.enabled = false;
                previousCam.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}
