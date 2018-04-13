using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Animation : MonoBehaviour {

    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {  
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        //   PM.enabled = true;
    }

    public void StartAnimation() {
        animator.SetBool("startAnim", true);
    }
}
