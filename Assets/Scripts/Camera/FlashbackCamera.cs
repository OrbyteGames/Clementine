using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackCamera : MonoBehaviour {

    public GameObject Clementine;
    public GameObject Marker1;
    public Camera previousCam;
    public float activationDist;
    public float duration;
    private float count;
    private Camera thisCam;
    private bool startCount, played;
    private UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl tpuc;
    private Vector3 posMarker;
    private FlashBackToyHorse fbth;

    // Use this for initialization
    void Start()
    {
        count = 0.0f;
        thisCam = gameObject.GetComponent<Camera>();
        thisCam.enabled = false;
        tpuc = Clementine.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        startCount = false;
         posMarker = Marker1.transform.position;
        fbth = gameObject.GetComponent<FlashBackToyHorse>();
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startCount)
        {          
            if ((Vector3.Distance(Clementine.transform.position, posMarker) < activationDist))
            {
                previousCam.enabled = false;
                thisCam.enabled = true;
                startCount = true;
                //tpuc.DisableMovement();
                fbth.StartScene();
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
                //tpuc.EnableMovement();
                thisCam.enabled = false;
                previousCam.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}
