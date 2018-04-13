using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Controller : MonoBehaviour {
    public GameObject motoLight;
    public GameObject fence;
    public GameObject clementine;
    public Transform target;
    public Puzzle1_Animation p1anim;
    public CatAI cat;

	private bool activated;
	// Use this for initialization
	void Start ()
    {
        motoLight.SetActive(false);
		activated = false;
	}
	
	// Update is called once per frame
	void Update ()
    {

        float step = 1f * Time.deltaTime;
        float dist = Vector3.Distance(clementine.transform.position, fence.transform.position);
		if (!activated) {
			if (dist < 5) {
				motoLight.SetActive (true);
				activated = true;
			} 
		}
		else {
			if (fence.transform.position.z > 33)
			{
				fence.transform.Translate(0f, -1 * Time.deltaTime, 0f);
			}
			else {
				cat.setSolved();

				enabled = false;
			}		
		}
    }
}
