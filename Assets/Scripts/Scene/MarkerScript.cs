using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerScript : MonoBehaviour {

    public enum markerType {OBJECTIVE_POINT, PASS_BY, PUZZLE_POINT, TORCH_POINT, FISHBONES };
    public GameObject previousMarker;
    public GameObject nextMarker;
    public markerType type;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject getNextMarker() {
        return nextMarker;
    }

    public GameObject getPreviousMarker() {
        return previousMarker;
    }

    public markerType getType() {
        return type;
    }

}
