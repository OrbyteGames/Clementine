using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoActiveCamera : MonoBehaviour
{

    [SerializeField]
    Camera _attachedCamera;
    bool hasExit = false;

    private void Start()
    {
        if (_attachedCamera == null)
            throw new System.Exception("You must attach a camera");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered: " + gameObject.name);
        _attachedCamera.gameObject.SetActive(true);
        if(CameraManager.Instance!=null)
            CameraManager.Instance.SwitchCamera(_attachedCamera);
       
        else
        {
            throw new System.Exception("You must add Camera manager script in the scene");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
