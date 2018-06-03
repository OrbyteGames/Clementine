using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Animation : MonoBehaviour
{

    Animator animator;
    public bool active = false;
    public bool solved = false;
    public bool IsAwake = false;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("wake") &&
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            //Waiting for WakeUp
            IsAwake = false;
        }
        else
        {
            
            if (active)
            {
                IsAwake = true;
                active = false;
                StartWalking();
            }
            else
            {
                if (solved) StopWalking();
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        //   PM.enabled = true;
    }
    public void nearActivate()
    {
        //animator.Play("wake");
    }

    public void StartWalking()
    {
        animator.SetBool("stopWalk", false);
        animator.SetBool("startWalk", true);
        // animator.Play("walk");
    }

    public void StopWalking()
    {
        animator.SetBool("startWalk", false);
        animator.SetBool("stopWalk", true);
        //animator.Play("idle");
    }
}
