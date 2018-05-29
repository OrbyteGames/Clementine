using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateClemController : MonoBehaviour {

    private Transform m_Cam;
    public bool camChanged;
    public bool movementEnabled;

    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;

    [SerializeField] float m_MovingTurnSpeed = 360;
    [SerializeField] float m_StationaryTurnSpeed = 180;
    [SerializeField] float m_GroundCheckDistance = 0.1f;
    Vector3 m_GroundNormal;
    public bool m_IsGrounded;
    float m_TurnAmount;
    float m_ForwardAmount;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (movementEnabled)
        {
        }

        if (camChanged)
        {
            UpdateCameraAxis(ref camChanged);
        }

    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (!movementEnabled)
        {
            h = 0;
            v = 0;
        }
        
        //--

        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v * m_CamForward + h * m_Cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_Move = v * Vector3.forward + h * Vector3.right;
        }

        //Moving
        MoveCharacter(m_Move);
    }

    void UpdateCameraAxis(ref bool hasChanged)
    {
        if (hasChanged)
        {  // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            hasChanged = false;
        }

    }

    void MoveCharacter(Vector3 move)
    {
        //Normalizing the vector
        if(move.magnitude>1f)
        {
            move.Normalize();
        }

        move = transform.InverseTransformDirection(move);
        CheckGroundStatus();
        move = Vector3.ProjectOnPlane(move, m_GroundNormal);

        m_TurnAmount = Mathf.Atan2(move.x, move.z);
        m_ForwardAmount = move.z;

        if(m_IsGrounded)
        {
            //Move
            
        }
        else
        {
            //in the air?
        }

    }

    void CheckGroundStatus()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
#endif
        // 0.1f is a small offset to start the ray from inside the character
        // it is also good to note that the transform position in the sample assets is at the base of the character
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
        {
            m_GroundNormal = hitInfo.normal;
            m_IsGrounded = true;
           
        }
        else
        {
            m_IsGrounded = false;
            m_GroundNormal = Vector3.up;
        }
    }

    void ApplyExtraTurnRotation()
    {
        // help the character turn faster (this is in addition to root rotation in the animation)
        float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
        transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
    }
}
