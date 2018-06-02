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
    private PlayerMovement pm;
    private Vector3 posMarker;
    private FlashBackToyHorse fbth;
    private FlashBackFamilyWindow fbfw;

    private float targetaspect = 16.0f/9.0f;
    float windowaspect, scaleheight;
    // Use this for initialization
    void Start()
    {
        count = 0.0f;
        thisCam = gameObject.GetComponent<Camera>();
        thisCam.enabled = false;
        //tpuc = Clementine.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        pm = Clementine.GetComponent<PlayerMovement>();
        startCount = false;
        posMarker = Marker1.transform.position;
        fbth = gameObject.GetComponent<FlashBackToyHorse>();
        fbfw = gameObject.GetComponent<FlashBackFamilyWindow>();
        played = false;
        windowaspect = (float)thisCam.pixelWidth / (float)thisCam.pixelHeight;
        scaleheight = windowaspect / targetaspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startCount)
        {          
            if ((Vector3.Distance(Clementine.transform.position, posMarker) < activationDist))
            {
                Rect rect= thisCam.rect;
                rect.width = 1.0f;
                rect.height = scaleheight;
                rect.x = 0;
                rect.y = (1.0f- scaleheight)/2.0f;
                thisCam.rect = rect;
                previousCam.enabled = false;
                thisCam.enabled = true;
                startCount = true;
                if (pm) pm.LockMovement();
                //tpuc.DisableMovement();
                if (fbth) fbth.StartScene();
                if (fbfw) fbfw.StartScene();
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
                if (pm) pm.UnlockMovement();
                thisCam.enabled = false;
                previousCam.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}
