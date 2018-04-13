using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLightUp : MonoBehaviour {

    private Light torchlight;
    private float count;
    private bool startLightUp;

    public float initialDelay = 1.0f;
    public float timeToLightUp = 3.0f;

	// Use this for initialization
	void Start () {
        count = 0.0f;
        torchlight = gameObject.GetComponent<Light>();
        torchlight.intensity = 0.0f;
        startLightUp = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (startLightUp)
        {
            count += Time.deltaTime;
            if (count > initialDelay)
            {
                if (torchlight.intensity < 10) torchlight.intensity += timeToLightUp / 10.0f;
            }
        }
	}

    public void StartLightUp() {
        startLightUp = true;
    }
}
