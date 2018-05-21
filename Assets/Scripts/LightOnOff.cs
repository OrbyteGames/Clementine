using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour {
    public Material OnMaterial;
    public Material OffMaterial;

    private Light objectlight;


    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = OffMaterial;

        objectlight = gameObject.GetComponent<Light>();
        if (objectlight) objectlight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Entered collider");
            gameObject.GetComponent<Renderer>().material = OnMaterial;
            if (objectlight) objectlight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Exited collider");
            gameObject.GetComponent<Renderer>().material = OffMaterial;
            if (objectlight) objectlight.enabled = false;
        }
    }
}
