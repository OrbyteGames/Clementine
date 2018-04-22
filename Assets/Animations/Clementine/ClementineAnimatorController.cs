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
        if (Input.GetKeyDown(KeyCode.Space)){
            anim.SetBool("climb", true);
            anim.SetBool("idleLook", false);
            anim.SetBool("idle", false);
            anim.SetBool("BeginWalk", false);
            anim.SetBool("walk", false);
            anim.SetBool("stopWalk", false);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            anim.SetBool("BeginWalk", true);
            anim.SetBool("idleLook", false);
            anim.SetBool("idle", false);
            anim.SetBool("climb0", false);
            anim.SetBool("walk", false);
            anim.SetBool("stopWalk", false);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.SetBool("walk", true);
            anim.SetBool("idleLook", false);
            anim.SetBool("idle", false);
            anim.SetBool("climb0", false);
            anim.SetBool("BeginWalk", false);
            anim.SetBool("stopWalk", false);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            anim.SetBool("stopWalk", true);
            anim.SetBool("idleLook", false);
            anim.SetBool("idle", false);
            anim.SetBool("climb0", false);
            anim.SetBool("walk", false);
            anim.SetBool("BeginWalk", false);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetBool("stopWalk", true);
            anim.SetBool("idleLook", false);
            anim.SetBool("idle", false);
            anim.SetBool("climb0", false);
            anim.SetBool("walk", false);
            anim.SetBool("BeginWalk", false);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetBool("idle", true);
            anim.SetBool("idleLook", false);
            anim.SetBool("stopWalk", false);
            anim.SetBool("climb0", false);
            anim.SetBool("walk", false);
            anim.SetBool("BeginWalk", false);
        }
        if (Input.GetKeyDown(KeyCode.K))
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
