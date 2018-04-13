using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_solved_cinematic : MonoBehaviour {

    public Camera cinematic_cam;
    public Camera[] puzzle_cam;
    public TorchLightUp[] lights;

    private CatAI cat;
    private bool startCinematic;
    private float count;
    private int camId;
	// Use this for initialization
	void Start () {
        startCinematic = false;
        count = 0.0f;
        cat = gameObject.GetComponent<CatAI>();
	}
	
	// Update is called once per frame
	void Update () {
        if (startCinematic) {
            count += Time.deltaTime;
            if (count > 7.0f) {
                FinishCinematic();
                count = 0.0f;
            }
        }
	}

    public void StartCinematic(int torch_index) {
        startCinematic = true;
        camId = torch_index;        
        cinematic_cam.enabled = true;
        puzzle_cam[torch_index].enabled = false;
        lights[torch_index].StartLightUp();
    }

    void FinishCinematic() {
        startCinematic = false;
        puzzle_cam[camId].enabled = true;
        cinematic_cam.enabled = false;
        cat.setCinematicFinished();
    }
}
