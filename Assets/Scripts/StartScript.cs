using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

    public GameObject player;
    private Vector3 initialPos;
    private float count ;
    private bool start;

	// Use this for initialization
	void Start () {
        start = true;
        count = 2.0f;
        initialPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            if (count < 0.0)
            {
                player.transform.position = new Vector3(1.0f, 0.7f, 2.15f);
                count = 0.0f;
                start = false;
            }
            else
            {
                count -= Time.deltaTime;
            }
        }
	}

    void Activate(){
        start = true;
    }

    void Deactivate(){
        start = false;
    }
}
