using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerScript : MonoBehaviour {

    public Material OnMaterial;
    public Material OffMaterial;

    private Light objectlight;
   
    private LightFlickerEffect lfe;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Renderer>().material = OffMaterial;
        lfe = gameObject.GetComponent<LightFlickerEffect>();

        objectlight = gameObject.GetComponent<Light>();
        if (objectlight) objectlight.enabled = false;
        lfe.enabled = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Entered collider");
            lfe.enabled = true;
            if (objectlight) objectlight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Exited collider");
            lfe.enabled = false;
            if (objectlight) objectlight.enabled = false;
        }
    }
}
