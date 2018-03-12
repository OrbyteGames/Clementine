using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float _speed = 150f;

    CharacterController _character;

    Camera _activedCamera;

    Rigidbody _rigidBody;

    // Use this for initialization
    void Start()
    {
        _character = GetComponent<CharacterController>();
        _rigidBody = GetComponent<Rigidbody>();
        CameraManager.Instance.OnCameraIsSwitched+=OnCameraIsSwitched;
        if (CameraManager.Instance.ActivedCamera == null)
        {
            _activedCamera = Camera.main;
        }

    }
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
        float axisX = Input.GetAxis("Horizontal");

        float axisY = Input.GetAxis("Vertical");

        if (axisX != 0 || axisY != 0 && _character.isGrounded)
            ManageMovement(axisX, axisY);

    }

    void ManageMovement(float axisX, float axisY)
    {
        Transform cameraTransform = _activedCamera.transform;
        Vector3 cameraRotation = _activedCamera.transform.rotation.eulerAngles;

        //A millorar!
        cameraRotation.x = 0;
        cameraTransform.eulerAngles = cameraRotation;

        Vector3 worldDirection=_activedCamera.transform.TransformDirection(axisX, 0, axisY);
        worldDirection.y = 0;
        worldDirection *= _speed * Time.deltaTime;
        _character.SimpleMove(worldDirection);
        if (worldDirection!=Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(worldDirection), Time.deltaTime * 20);
        
    }
}
