using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Controller : MonoBehaviour {
    public GameObject shadow;
    public GameObject clementine;
    public GameObject container;
    public GameObject RobotLight;
    public Transform target;
    Material material;
    public float robotSpeed = 1;
    Rigidbody containerRB;
    public int puzzleTriggerDist;
    // Use this for initialization
    void Start ()
    {
        shadow.SetActive(false);
        RobotLight.SetActive(false);
        material = GetComponent<Renderer>().material;
       containerRB = container.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float step = robotSpeed * Time.deltaTime;
        float dist = Vector3.Distance(clementine.transform.position, transform.position);
        if (dist< puzzleTriggerDist)
        {
            RobotLight.SetActive(true);
            shadow.SetActive(true);
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            
        }
        if(transform.position == target.position)
        {
            containerRB.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

}
