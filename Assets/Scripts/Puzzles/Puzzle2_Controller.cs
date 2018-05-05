using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Controller : MonoBehaviour {
    public GameObject shadow,clementine, container, RobotLight;
    public Transform target;
    Material material;
    public float robotSpeed = 1;
    public float energyIncreaseValue;
    Rigidbody containerRB;
    public int puzzleTriggerDist;
    public CatAI cat;
    private float storedEnergy;
    private bool startWalking;
    // Use this for initialization
    void Start ()
    {
        energyIncreaseValue = 10.0f;
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
            if (!startWalking)
            {
                if (Input.GetButton("Fire1"))
                {
                    storedEnergy += energyIncreaseValue;
                }
                if (storedEnergy > 50) startWalking = true;
            }
            else
            {
                RobotLight.SetActive(true);
                shadow.SetActive(true);
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
        }
        if(transform.position == target.position)
        {
            containerRB.constraints = RigidbodyConstraints.FreezeAll;
            cat.setSolved();
            enabled = false;
        }
    }

}
