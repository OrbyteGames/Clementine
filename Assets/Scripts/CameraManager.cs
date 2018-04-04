using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Singleton class, manage all the cameras in the game
/// </summary>
public class CameraManager : MonoBehaviour
{
    #region Delegates and Events
    public delegate void CameraDelegate(Camera camera);

    public event CameraDelegate OnCameraIsSwitched;

    #endregion

    //Instance getter
    public static CameraManager Instance
    {

        get
        {
            return _instance;
        }
    }

    //Active camera getter
    public Camera ActiveCamera
    {

        get
        {
            return _activeCamera;
        }
    }

    static CameraManager _instance=null;


    Camera _activeCamera=null;


    // Use this for initialization
    void Start()
    {
        if (_instance != null)
            throw new System.Exception("Can not exist more than one instance of camera manager");
        else
            _instance = this;
        

    }



    /// <summary>
    /// Switch the actual camera if is not equal and callback the event subscribers
    /// </summary>
    /// <param name="cam"></param>
    public void SwitchCamera(Camera cam)
    {
        if (_activeCamera != cam)
        {
            if (_activeCamera != null)
                _activeCamera.gameObject.SetActive(false);
            _activeCamera = cam;
            if (OnCameraIsSwitched != null)
                OnCameraIsSwitched(_activeCamera);
        }
    }
}
