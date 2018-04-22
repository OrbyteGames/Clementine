using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Controller : MonoBehaviour {
    public Light motoLight;
    public GameObject[] fences;
    public GameObject clementine;
    public GameObject wheel, fencewheel1,fencewheel2,lights, electricity;
    public CatAI cat;
    public float puzzleDist;
    public ParticleSystem ps,ps2;
    [Range(2f,4.2f)]
    public float fenceHeight;
    private Puzzle1_Animation pa1;
	private bool activated;
    public bool solved;
    private float psCounter;
	// Use this for initialization
	void Start ()
    {
        psCounter = 0.0f;
        lights.SetActive(false);
		activated = false;
        solved = false;
        pa1 = gameObject.GetComponent<Puzzle1_Animation>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        wheel.transform.Rotate(-10f * Time.deltaTime, 0f, 0f);

        float step = 1f * Time.deltaTime;
        float dist = Vector3.Distance(clementine.transform.position, gameObject.transform.position); //fences[0].transform.position);
        if (!activated) {
            if (dist < puzzleDist)
            {
                if (psCounter > 2.0f)
                {
                    

                    
                    activated = true;
                    lights.SetActive(true);
                    Destroy(ps);
                }
                else
                {
                    if (!ps.isPlaying)ps.Play();
                    //ps2.Play();
                    psCounter += Time.deltaTime;
                }
               
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
                    fence.transform.Translate(0f, 0.3f * Time.deltaTime, 0f);
                    fencewheel1.transform.Rotate(0f, 0f, - 10f * Time.deltaTime );
                    fencewheel2.transform.Rotate(0f, 0f, - 10f * Time.deltaTime);
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
