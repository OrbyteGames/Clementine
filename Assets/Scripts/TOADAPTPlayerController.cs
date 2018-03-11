using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float inputDelay = 0.1f;
    public float forwardVel = 12;
    public float rotateVel = 100;

    Quaternion targetRotation;
    Rigidbody rBody;

    float forwardInput, turnInput;

    //Because we might want to access the rotation of the character
    //from the player controller
    public Quaternion TargetRotation
    {
        get { return TargetRotation; }
    }

    private void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("The character needs a rigidbody");

        forwardInput = turnInput = 0;
    }
    void GetInput()
    {
        //Go check Input Settings in UNITY
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }
        
 
    void Update ()
    {
        GetInput();
        Turn();
    }

    private void FixedUpdate()
    {
        Run();   
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            //move
            rBody.velocity = transform.forward * forwardInput * forwardVel;
        }
        else
            //zero velocity
            rBody.velocity = Vector3.zero;
    }
    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }
            transform.rotation = targetRotation;
    }

}
