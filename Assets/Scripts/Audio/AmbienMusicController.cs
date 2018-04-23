using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienMusicController : MonoBehaviour {

    public GameObject soundMarker;
    public GameObject player;
    public float activationDist;
    public AudioSource source;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(player.transform.position, soundMarker.transform.position) < activationDist)
        {
            source.Play();
            Destroy(this);
        }
	}
}
