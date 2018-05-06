using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class AutoActiveCamera : MonoBehaviour
{

    [SerializeField]
    Camera _attachedCamera;
    public Transform forwardPoint;
    public GameObject clement;
    bool hasChanged = true;
    bool hasExit = false;
    private ThirdPersonUserControl clem_control;
    private void Start()
    {
        clem_control = clement.GetComponent<ThirdPersonUserControl>();
  
        if (_attachedCamera == null)
            throw new System.Exception("You must attach a camera");
        clement.transform.forward = forwardPoint.forward;
    }
    private void Update()
    {

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 
            && hasChanged == false )
        {
            clem_control.camChanged = true;

            //hasChanged = true;
            ////clement.transform.forward = forwardPoint.forward;


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Entered: " + gameObject.name);
            _attachedCamera.gameObject.SetActive(true);
            _attachedCamera.tag = "MainCamera";
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
