using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 6.0f;
    public float gravity = 10.0f;
    public float turnSmooth = 15.0f;
    public bool airFlight = true;
    public float jumpforce = 14.0f;

    private bool start;
    private CharacterController playerController;
    private Camera actualCamera;
    private float verticalVelocity;
    // Use this for initialization
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;


        transform.Translate(x, z, 0);
    }
}
