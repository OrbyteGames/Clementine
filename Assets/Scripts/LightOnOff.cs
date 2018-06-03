﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnOff : MonoBehaviour {
    public Material OnMaterial;
    public Material OffMaterial;

    private Light objectlight;

    public GameObject player;
    public float minDistance = 2.0f;
    private bool inside;
    private Vector3 playerPosGround;
    private Vector3 objectPosGround;
    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = OffMaterial;
        objectlight = gameObject.GetComponent<Light>();
        objectPosGround = new Vector3(gameObject.transform.position.x,0, gameObject.transform.position.z);
        if (objectlight) objectlight.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPosGround = new Vector3( player.transform.position.x,0, player.transform.position.z);
        if (!inside)
        {
            if (Vector3.Distance(playerPosGround, objectPosGround) < minDistance) {
                inside = true;
                gameObject.GetComponent<Renderer>().material = OnMaterial;
                if (objectlight) objectlight.enabled = true;
            }
        }
        else {
            if (Vector3.Distance(playerPosGround, objectPosGround) > minDistance) {
                inside = false;
                gameObject.GetComponent<Renderer>().material = OffMaterial;
                if (objectlight) objectlight.enabled = false;
            }
        }
    }
    /*
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().material = OnMaterial;
            if (objectlight) objectlight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().material = OffMaterial;
            if (objectlight) objectlight.enabled = false;
        }
    }*/
}