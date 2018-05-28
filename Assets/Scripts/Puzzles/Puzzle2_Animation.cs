﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Animation : MonoBehaviour {

    Animator animator;
    public bool active = false;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        if (active) {
            active = false;
            StartWalking();
        }else
        {
            //StopWalking();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        //   PM.enabled = true;
    }

    public void StartWalking()
    {
        animator.SetBool("stopWalk", false);
        animator.SetBool("startWalk", true);
    }

    public void StopWalking()
    {
        animator.SetBool("startWalk", false);
        animator.SetBool("stopWalk", true);
    }
}
