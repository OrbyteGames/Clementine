using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour {

    public Transform origin;
    public Transform destination;

    public NavMeshAgent agent;
	// Use this for initialization
	void Start ()
    {
        transform.position = origin.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float dist = Vector3.Distance(transform.position, origin.position);
        if(dist < 2f)
            agent.SetDestination(destination.position);
       float  dist2 = Vector3.Distance(transform.position, destination.position);
        if (dist2 < 2f)
            agent.SetDestination(origin.position);

             
	}
}
