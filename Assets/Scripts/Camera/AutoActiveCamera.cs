using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoActiveCamera : MonoBehaviour
{

    [SerializeField]
    Camera _attachedCamera;

    private void Start()
    {
        if (_attachedCamera == null)
            throw new System.Exception("You must attach a camera");
    }

    private void OnTriggerEnter(Collider other)
    {
        _attachedCamera.gameObject.SetActive(true);
    }
}
