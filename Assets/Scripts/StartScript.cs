using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

    public GameObject player;
    private Vector3 initialPos;
    private float count ;
    private bool start;
    public PlayerController pc;

    // Use this for initialization
    void Start () {
        start = false;
        count = 2.0f;
        initialPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            if (count < 0.0)
            {
                player.transform.position = new Vector3(1.0f, 0.07f, 2.15f);
                pc.StartCharacter();

                count = 0.0f;
                start = false;
            }
            else
            {
                count -= Time.deltaTime;
            }
        }
	}

    public void Activate(){
        start = true;
    }

    public void Deactivate(){
        start = false;
    }
}
