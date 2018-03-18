using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 6.0f;
    public float gravity = 10.0f;
    public float turnSmooth = 15.0f;
    public bool airFlight = true;
    public float jumpforce = 14.0f;

    private bool start ;
    private CharacterController playerController;
    private Camera actualCamera;
    private float verticalVelocity;
	// Use this for initialization
	void Start () {
        start = false;
        playerController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            Vector3 movement = (new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"))) * speed;
            float y = Input.GetAxis("Horizontal");
            //float x = Input.GetAxis("Vertical");
            verticalVelocity = 0.0f;
            movement = transform.TransformDirection(movement);
            if (!playerController.isGrounded)
            {
                //if (airFlight) 
               // else movement = new Vector3(0, -gravity, 0);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (playerController.isGrounded) movement.y = jumpforce;              
            }
            movement.y -= gravity;
            playerController.Move(movement * Time.deltaTime);
        }
        //Movement();
    }

    public void Movement()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");
        if (InputX != 0 || InputY != 0)
        {
            Vector3 movement = new Vector3(InputX, 0.0f, InputY);
            Quaternion targetrotation = Quaternion.LookRotation(movement,Vector3.up);
            Quaternion lerpedrotation = Quaternion.Lerp(playerController.transform.rotation, targetrotation,turnSmooth*Time.deltaTime);
            movement = transform.TransformDirection(movement);
            if (!playerController.isGrounded)
            {
                if (airFlight) movement.y -= gravity;
                else movement = new Vector3(0, -gravity, 0);
            }
            playerController.transform.Rotate(lerpedrotation.eulerAngles);
            playerController.Move(movement * Time.deltaTime);
        }
    }

    public void StartCharacter()
    {
        start = true;
    }

    public void PauseCharacter()
    {
        start = false;
    }
}


