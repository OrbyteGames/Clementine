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


    public static CameraManager Instance
    {

        get
        {
            return _instance;
        }
    }
    public Camera ActivedCamera
    {

        get
        {
            return _activedCamera;
        }
    }

    static CameraManager _instance;


    Camera _activedCamera;


    // Use this for initialization
    void Start()
    {
        if (_instance != null)
            throw new System.Exception("Can not exist more than one instance of camera manager");
        else
        {
            _instance = this;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// Switch the actual camera if is not equal and callback the event subscribers
    /// </summary>
    /// <param name="cam"></param>
    public void SwitchCamera(Camera cam)
    {
        if (_activedCamera != cam)
        {
            _activedCamera = cam;
            if (OnCameraIsSwitched != null)
                OnCameraIsSwitched(_activedCamera);
        }
    }
}
