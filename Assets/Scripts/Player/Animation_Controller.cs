using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animations;

public class Animation_Controller : MonoBehaviour
{

    Animator animator;
    CharacterController CC;
    //PlayerMovement PM;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        CC = GetComponent<CharacterController>();
       // PM = GetComponent<PlayerMovement>();


      //  PM.enabled = false;
        StartCoroutine(Wait());

    }

    // Update is called once per frame
    void Update()
    {
        
        if ( Mathf.Abs(CC.velocity.x) > 0.5 || Mathf.Abs(CC.velocity.z) > 0.5)
        {
            animator.SetBool("isWalking", true);
        }

        else animator.SetBool("isWalking", false);


    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);


     //   PM.enabled = true;
    }
}