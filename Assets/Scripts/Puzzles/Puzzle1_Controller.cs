using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Controller : MonoBehaviour {
    public Light motoLight;
    public GameObject[] fences;
    public GameObject clementine;
    public GameObject wheel, fencewheel1,fencewheel2,lights;
    public CatAI cat;
    public float puzzleDist;
    [Range(2f,4.2f)]
    public float fenceHeight;
    private Puzzle1_Animation pa1;
	private bool activated;
    public bool solved;
	// Use this for initialization
	void Start ()
    {
        lights.SetActive(false);
		activated = false;
        solved = false;
        pa1 = gameObject.GetComponent<Puzzle1_Animation>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        float step = 1f * Time.deltaTime;
        float dist = Vector3.Distance(clementine.transform.position, gameObject.transform.position); //fences[0].transform.position);
        if (!activated) {
			if (dist < puzzleDist) {			
				activated = true;
                lights.SetActive(true);
            }
        }
		else {
            /*if (motoLight.intensity < 5 && !solved)
            {
                motoLight.intensity += 2.0f * Time.deltaTime;
            }*/
            
            foreach (GameObject fence in fences)
            {
                if (fence.transform.position.y < fenceHeight)
                {
                    fence.transform.Translate(0f, 1f * Time.deltaTime, 0f);
                    wheel.transform.Rotate( -45f * Time.deltaTime, 0f, 0f);
                    fencewheel1.transform.Rotate(0f, 0f, - 45f * Time.deltaTime );
                    fencewheel2.transform.Rotate(0f, 0f, - 45f * Time.deltaTime);
                }
                else
                {
                    if (!solved) solved = true;
                }

            }

            if (solved)
            {
                if (cat != null)
                {
                    cat.setSolved();
                }
                /* if (motoLight.intensity > 0.0f)
                 {
                     motoLight.intensity -= 3.0f * Time.deltaTime;
                 }*/
                lights.SetActive(false);
                pa1.StartAnimation();
                enabled = false;
            }                      
        }
    }
}
