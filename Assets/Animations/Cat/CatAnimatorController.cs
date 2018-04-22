using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimatorController : MonoBehaviour
{

    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            anim.SetBool("idle", true);
            anim.SetBool("walk", false);
        }
        if (Input.GetKeyDown("2"))
        {
            anim.SetBool("idle", false);
            anim.SetBool("walk", true);

        }
    }
}