using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float _speed = 150f;

    [SerializeField]
    float _jumpForce;

    [SerializeField]
    float _gravity = 1;
    bool _isWalking = false;

    CharacterController _character;

    Camera _activedCamera;

    Rigidbody _rigidBody;
    Animator _animator;
    bool _isMovementLocked = false;
    bool _isJumpLocked = false;
    bool _isJumping = false;

    float _verticalVelocity = 0;


    // Use this for initialization
    void Start()
    {
        _character = GetComponent<CharacterController>();
        _rigidBody = GetComponent<Rigidbody>();
        CameraManager.Instance.OnCameraIsSwitched += OnCameraIsSwitched;
        if (CameraManager.Instance.ActiveCamera == null)
            _activedCamera = Camera.main;

        _animator = GetComponent<Animator>();
    }

    void LockMovement()
    {
        _isMovementLocked = true;
    }

    void UnlockMovement()
    {
        _isMovementLocked = false;
    }

    void LockJump()
    {
        _isJumpLocked = true;
    }

    void UnlockJump() { _isJumpLocked = false; }
    private void OnDestroy()
    {
        if (CameraManager.Instance)
            CameraManager.Instance.OnCameraIsSwitched -= OnCameraIsSwitched;
    }

    void OnCameraIsSwitched(Camera cam)
    {
        _activedCamera = cam;
    }


    private void Update()
    {
        ManageMovement();

    }

    void ManageMovement()
    {
        _activedCamera = CameraManager.Instance.ActiveCamera;
        Vector3 moveDirection = Vector3.zero;
        float axisX = Input.GetAxis("Horizontal");

        float axisY = Input.GetAxis("Vertical");

        Transform cameraTransform = _activedCamera.transform;
        Vector3 cameraRotation = _activedCamera.transform.rotation.eulerAngles;
        Vector2 lastCameraRotation = cameraRotation;
        //A millorar!
        cameraRotation.x = 0;
        cameraTransform.eulerAngles = cameraRotation;
        Vector3 worldDirection = _activedCamera.transform.TransformDirection(axisX, 0, axisY);
        worldDirection.y = 0;
        worldDirection *= _speed;

        if (worldDirection != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(worldDirection), Time.deltaTime * 20);

        if (_character.isGrounded)
        {
            

            _verticalVelocity = -_gravity * Time.deltaTime;

            if (Input.GetButtonDown("Jump"))
            {
                _verticalVelocity = _jumpForce;
            }
            else
            {
                if (!_isWalking && new Vector2(axisX, axisY).normalized.magnitude >= 0.01f)
                {
                    Debug.Log("Walking");

                    _animator.SetBool("Walking",true);

                    _animator.SetBool("Idle", false);
                    _isWalking = true;
                }
                else if (_isWalking)
                {
                    Debug.Log("Iddle");
                    _isWalking = false;
                    _animator.SetBool("Idle", true);
                    _animator.SetBool("Walking", false);
                }
            }
        }
        else
            _verticalVelocity -= _gravity * Time.deltaTime;


        worldDirection.y = _verticalVelocity;
        moveDirection = worldDirection * Time.deltaTime;

        _character.Move(moveDirection);


        cameraTransform.eulerAngles = lastCameraRotation;


    }




    void ManageGravity()
    {

    }
}
