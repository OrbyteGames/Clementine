using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    Vector3 newPosition;
    private bool toMove;
    private bool toRotate;
    public float speed = 3f;
    int Layer = 0;
    
    void Start()
    {
        newPosition = transform.position;
        toMove = false;
        toRotate = false;
        Layer = LayerMask.GetMask("Default");
       
       
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
           
            Ray ray = CameraManager.Instance.ActiveCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit,Mathf.Infinity,Layer))
            {
                newPosition = hit.point;
                toMove = true;
                
            }
           
        }
        if (toMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, newPosition) < 0.5f)
        {
            toMove = false;
        }
      
    }
}