using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoActiveCamera : MonoBehaviour
{

    [SerializeField]
    Camera _attachedCamera;
    public Transform forwardPoint;
    public GameObject clement;
    bool hasChanged = true;
    bool hasExit = false;

    private void Start()
    {
        if (_attachedCamera == null)
            throw new System.Exception("You must attach a camera");
        clement.transform.forward = forwardPoint.forward;
    }
    private void Update()
    {

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 
            && hasChanged == false )
        {
            hasChanged = true;
            clement.transform.forward = forwardPoint.forward;
             Debug.Log( forwardPoint.gameObject.name);
          
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Entered: " + gameObject.name);
            _attachedCamera.gameObject.SetActive(true);
            hasChanged = false;
            if (CameraManager.Instance != null)
            {
                CameraManager.Instance.SwitchCamera(_attachedCamera);
               
                return;
            }

            else
            {
                throw new System.Exception("You must add Camera manager script in the scene");
            }
        }
      
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
