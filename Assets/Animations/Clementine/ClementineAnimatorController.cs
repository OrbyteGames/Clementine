using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClementineAnimatorController : MonoBehaviour {
    Animator anim;
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("1")){
            anim.SetBool("climb", true);
            anim.SetBool("idleLook", false);
            anim.SetBool("idle", false);
            anim.SetBool("BeginWalk", false);
            anim.SetBool("walk", false);
            anim.SetBool("stopWalk", false);
        }
        if (Input.GetButtonDown("2"))
        {
            anim.SetBool("BeginWalk", true);
            anim.SetBool("idleLook", false);
            anim.SetBool("idle", false);
            anim.SetBool("climb0", false);
            anim.SetBool("walk", false);
            anim.SetBool("stopWalk", false);
        }
        if (Input.GetButtonDown("3"))
        {
            anim.SetBool("walk", true);
            anim.SetBool("idleLook", false);
            anim.SetBool("idle", false);
            anim.SetBool("climb0", false);
            anim.SetBool("BeginWalk", false);
            anim.SetBool("stopWalk", false);
        }
        if (Input.GetButtonDown("4"))
        {
            anim.SetBool("stopWalk", true);
            anim.SetBool("idleLook", false);
            anim.SetBool("idle", false);
            anim.SetBool("climb0", false);
            anim.SetBool("walk", false);
            anim.SetBool("BeginWalk", false);
        }
        if (Input.GetButtonDown("5"))
        {
            anim.SetBool("stopWalk", true);
            anim.SetBool("idleLook", false);
            anim.SetBool("idle", false);
            anim.SetBool("climb0", false);
            anim.SetBool("walk", false);
            anim.SetBool("BeginWalk", false);
        }
        if (Input.GetButtonDown("6"))
        {
            anim.SetBool("idle", true);
            anim.SetBool("idleLook", false);
            anim.SetBool("stopWalk", false);
            anim.SetBool("climb0", false);
            anim.SetBool("walk", false);
            anim.SetBool("BeginWalk", false);
        }
        if (Input.GetButtonDown("7"))
        {
            anim.SetBool("idleLook", true);
            anim.SetBool("idle", false);
            anim.SetBool("stopWalk", false);
            anim.SetBool("climb0", false);
            anim.SetBool("walk", false);
            anim.SetBool("BeginWalk", false);
        }
        // float move = Input.GetAxis("Vertical");

    }
}
