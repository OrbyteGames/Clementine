using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Controller : MonoBehaviour {
    public GameObject motoLight;
    public GameObject fence;
    public GameObject clementine;
    public Transform target;
    float step = 1f * Time.deltaTime;

	// Use this for initialization
	void Start ()
    {
        motoLight.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        float dist = Vector3.Distance(clementine.transform.position, fence.transform.position);
        if (dist<5)
        {
            motoLight.SetActive(true);
            if (fence.transform.position.z > 33)
            {
                fence.transform.Translate(0f, -1 * Time.deltaTime, 0f);
            }
        }

    }
}
