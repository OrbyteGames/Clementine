using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animations;

public class Animation_Controller_Cat : MonoBehaviour
{
    Animator animator;
    CharacterController CC;
    private bool cinematic1;
    private bool puzzleResolved;

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

        if (Mathf.Abs(CC.velocity.x) > 0.5 || Mathf.Abs(CC.velocity.z) > 0.5)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (cinematic1)
        {
            if (puzzleResolved) { 
                animator.SetBool("isTrapped", false);
                animator.SetBool("isMagic", true);
                cinematic1 = false;
            }
            else
            { 
                animator.SetBool("isTrapped", true);
            }
        }
        else
        {
            animator.SetBool("isMagic", false);
            //include other actions during CatIA it depends of the zoneMap.

        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);


        //   PM.enabled = true;
    }
}