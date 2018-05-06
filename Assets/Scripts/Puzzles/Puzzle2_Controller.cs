using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Controller : MonoBehaviour {
    public GameObject clementine, container, RobotLight;
    public Transform target;
    Material material;
    public float robotSpeed = 1;
    public float energyIncreaseValue;
    public int puzzleTriggerDist;
    public CatAI cat;
    private float storedEnergy;
    private bool startWalking;
    // Use this for initialization
    void Start ()
    {
        energyIncreaseValue = 10.0f;
        RobotLight.SetActive(false);
        material = GetComponent<Renderer>().material;
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
                if (storedEnergy > 50)
                {
                    RobotLight.SetActive(true);
                    startWalking = true;
                }
            }
            else
            {
                transform.position += new Vector3(-robotSpeed, 0.0f,0.0f);
            }
        }
        if(Mathf.Abs(transform.position.x) <= Mathf.Abs(target.position.x - 0.1f))
        {
            startWalking = false;
            cat.setSolved();
            enabled = false;
        }
    }

}
