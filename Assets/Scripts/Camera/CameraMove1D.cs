using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove1D : MonoBehaviour {
    public GameObject clemen;
    public bool x=false, y=false, z = false;
    public float step = 10f;
    public float distanceX = 0f, distanceY = 0f, distanceZ = 5f;
    // Use this for initialization
    void Start ()
    {
     
    }

    private void Update()
    {
      if(x)
        {
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, clemen.transform.position.x - distanceX, step * Time.deltaTime), transform.position.y, transform.position.z);
        }
      if(z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.MoveTowards(transform.position.z, clemen.transform.position.z-distanceZ, step * Time.deltaTime));

        }
      else
        {
            transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, clemen.transform.position.y - distanceY, step * Time.deltaTime), transform.position.z);

        }

    }

}
