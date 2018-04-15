﻿using UnityEngine;
using System.Collections;


    public class CameraController : MonoBehaviour
    {

        
        float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
        float maxShift = 1000.0f; //Maximum speed when holdin gshift
        float camSens = 0.25f; //How sensitive it with mouse
        private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
        private float totalRun = 1.0f;

        public float Sensitivity;
        public bool YInvert;
        public float mainSpeed = 100.0f; //regular speed

    // holds lock values to manage the Windows cursor
    CursorLockMode lockMode;

    void Awake()
    {
        lockMode = CursorLockMode.Locked;
        Cursor.lockState = lockMode;
    }


    private void Start()
    {
        //Hide the cursor
        Cursor.visible = false;
    }

    void Update()
        {
            float rotationY = Input.GetAxis("Mouse X") * Sensitivity;
            float rotationX = 0;
            if (YInvert)
            {
                rotationX = -Input.GetAxis("Mouse Y") * Sensitivity;
            }
            else
            {
                rotationX = Input.GetAxis("Mouse Y") * Sensitivity;
            }

            transform.Rotate(new Vector3(rotationX, rotationY));
            Vector3 ea = transform.eulerAngles;
            transform.eulerAngles = new Vector3(ea.x, ea.y, 0);

            //camera angle done.  

            //Keyboard commands
            float f = 0.0f;
            Vector3 p = GetBaseInput();
            if (Input.GetKey(KeyCode.LeftShift))
            {
                totalRun += Time.deltaTime;
                p = p * totalRun * shiftAdd;
                p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
                p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
                p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
            }
            else
            {
                totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
                p = p * mainSpeed;
            }

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            if (Input.GetKey(KeyCode.Space))
            { //If player wants to move on X and Z axis only
                transform.Translate(p);
                newPosition.x = transform.position.x;
                newPosition.z = transform.position.z;
                transform.position = newPosition;
            }
            else
            {
                transform.Translate(p);
            }

        }


        private Vector3 GetBaseInput()
        { //returns the basic values, if it's 0 than it's not active.
            Vector3 p_Velocity = new Vector3();
            if (Input.GetKey(KeyCode.W))
            {
                p_Velocity += new Vector3(0, 0, 1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                p_Velocity += new Vector3(0, 0, -1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                p_Velocity += new Vector3(-1, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                p_Velocity += new Vector3(1, 0, 0);
            }
            return p_Velocity;
        }

    }