﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Controller : MonoBehaviour {

    enum SoundState { NONE, SOUNDELEC, SOUNDENGINE, SOUNDDOOR };
    private SoundState actualState;
    public GameObject[] fences;
    public GameObject clementine;
    public GameObject wheel, fencewheel1, fencewheel2, lights, electricity;
    public CatAI cat;
    public bool solved;
    public float puzzleDist, Counter, electTimestamp, engineTimeStamp, doorTimeStamp, energyIncreaseValue;
    [Range(2f, 4.2f)]
    public float fenceHeight;
    public ParticleSystem ps, ps2, particleAura;
    public AudioSource electricitySound, EngineSound, doors;
    public float storedEnergy;
    private Puzzle1_Animation pa1;
    private bool activated, startCount, startPlaying;
    private Animator anim;
    private FlickeringLight flickering;
    public int IntensityAura = 0;
    // Use this for initialization
    void Start ()
    {
        startPlaying = false;
        startCount = false;
        actualState = SoundState.NONE;
        Counter = 0.0f;
        energyIncreaseValue = 10.0f;
        storedEnergy = 0.0f;
        lights.SetActive(false);
		activated = false;
        solved = false;
        pa1 = gameObject.GetComponent<Puzzle1_Animation>();
        anim = gameObject.GetComponent<Animator>();
        flickering = gameObject.GetComponent<FlickeringLight>();
        flickering.duration = doorTimeStamp;
	}
	
	// Update is called once per frame
	void Update ()
    {
        wheel.transform.Rotate(-10f * Time.deltaTime, 0f, 0f);
        float step = 1f * Time.deltaTime;
        float dist = Vector3.Distance(clementine.transform.position, gameObject.transform.position); //fences[0].transform.position);
        if (startCount) Counter += Time.deltaTime;
        if (!startPlaying && !activated)
        {
            if (storedEnergy > 0)storedEnergy -= Time.deltaTime;
            if (dist < puzzleDist)
            {
                particleAura.Play(true);
                if(IntensityAura<5)particleAura.Emit(IntensityAura + 1);
                if (Input.GetButtonDown("Fire1"))
                {
                    storedEnergy += energyIncreaseValue;
                }
                if (storedEnergy > 50) startPlaying = true;
            }else
            {
                if (IntensityAura > 0) particleAura.Emit(IntensityAura--);
                else if (IntensityAura == 0) particleAura.Stop();
            }
        }
        else { 
            startCount = true;
            if (Counter > 2.0f)
            {
                activated = true;
                lights.SetActive(true);
                Destroy(ps);
                startPlaying = false;
            }
            else
            {
                if (actualState == SoundState.NONE && Counter > electTimestamp )
                {
                    flickering.StartFlicker();
                    actualState = SoundState.SOUNDELEC;
                    electricitySound.Play();
                }
                else if (actualState == SoundState.SOUNDELEC && Counter > engineTimeStamp)
                {
                    actualState = SoundState.SOUNDENGINE;
                    EngineSound.Play();
                    anim.Play("RunMoto");
                }
                if (!ps.isPlaying) ps.Play();
            }          
        }
		if (activated) {

            if (actualState == SoundState.SOUNDENGINE && Counter > doorTimeStamp)
            {
                actualState = SoundState.SOUNDDOOR;
                doors.Play();
            }
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
                    doors.Stop();
                    if (!solved) solved = true;
                }
            }

            if (solved)
            {
                if (cat != null)
                {
                    cat.setSolved();
                }

                pa1.StartAnimation();
                enabled = false;
            }                      
        }
    }
}
