using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Controller : MonoBehaviour {

    public GameObject bridge, player;
    public Light spotlight;
    public float bridgeDuration = 5.0f;
    public float energyIncreaseValue = 10.0f;
    private bool startcountdown = false;
    public float counter, activationDistance;
    private float storedEnergy;
	// Use this for initialization
	void Start ()
    {
        counter = 0.0f;
        storedEnergy = 0.0f;
        energyIncreaseValue = 10.0f;
        spotlight.enabled = false;
        bridge.SetActive(false);
        bridge.GetComponent<BoxCollider>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (startcountdown)
        {
            counter += Time.deltaTime;
            if (counter >= bridgeDuration)
            {
                counter = 0.0f;
                bridge.SetActive(false);
                startcountdown = false;
                spotlight.enabled = false;
                bridge.GetComponent<BoxCollider>().enabled = false;
            }
        }
        /*
         check if in distance
         */
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < activationDistance) {
            if (Input.GetButtonDown("Fire1"))
            {
                storedEnergy += energyIncreaseValue;
                if (storedEnergy > 50)
                {
                    spotlight.enabled = true;
                    bridge.SetActive(true);
                    bridge.GetComponent<BoxCollider>().enabled = true;
                    startcountdown = true;
                    counter = 0.0f;
                }
            }
        }
    }


}
