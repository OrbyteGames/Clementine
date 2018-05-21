using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// Written by Steve Streeting 2017
// License: CC0 Public Domain http://creativecommons.org/publicdomain/zero/1.0/

/// <summary>
/// Component which will flicker a linked light while active by changing its
/// intensity between the min and max values given. The flickering can be
/// sharp or smoothed depending on the value of the smoothing parameter.
///
/// Just activate / deactivate this component as usual to pause / resume flicker
/// </summary>
public class LightFlickerEffect : MonoBehaviour
{
    [Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
    public new Light light;
    public float maxDistance = 3f;
    [Tooltip("Minimum random light intensity")]
    public float minIntensity = 0f;
    [Tooltip("Maximum random light intensity")]
    public float maxIntensity = 9f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 50)]
    public int smoothing = 5;
   

    // Continuous average calculation via FIFO queue
    // Saves us iterating every time we update, we just change by the delta
    Queue<float> smoothQueue;
    float lastSum = 0;

    public Material OnMaterial;
    public Material OffMaterial;

    bool loop;
    public float minFlickeringTime, maxFlickeringTime;
    public float minPauseTime, maxPauseTime;
    public int maxFlickerings;
    [SerializeField]
    private float pauseTime, flickeringTime;
    [SerializeField]
    private int numFlickerings;
    private bool pause;
    /// <summary>
    /// Reset the randomness and start again. You usually don't need to call
    /// this, deactivating/reactivating is usually fine but if you want a strict
    /// restart you can do.
    /// </summary>
    public void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start()
    {
        loop = false;
        pause = false;
        smoothQueue = new Queue<float>(smoothing);
        // External or internal light?
        if (light == null)
        {
            light = gameObject.GetComponent<Light>();
        }
        pauseTime = 0;
        flickeringTime = Random.Range(minFlickeringTime,maxFlickeringTime);
        numFlickerings = Random.Range(1,maxFlickerings);
        //StartCoroutine(Cooldown());
    }

    void Update()
    {
        if (light == null)
            return;
        // pop off an item if too big

    }

    IEnumerator Cooldown()
    {
        //Reset Values
        float count = 0;
        while (loop)
        {
            if (!pause)
            {
                yield return new WaitForSeconds(flickeringTime);

                Flickering();
                if (numFlickerings <= 0)
                {
                    flickeringTime = Random.Range(minFlickeringTime, maxFlickeringTime);
                    pauseTime = Random.Range(minPauseTime, maxPauseTime);
                    numFlickerings = Random.Range(1, maxFlickerings);
                    count = 0.0f;
                    pause = true;
                }
            }
            else
            {
                yield return new WaitForSeconds(pauseTime);
                pause = false;
            }
        }
        light.enabled = false;
        gameObject.GetComponent<Renderer>().material = OffMaterial;
    }


    void Flickering()
    {
        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }
        // Generate random new item, calculate new average
        float newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;
        // Calculate new smoothed average

        //light.intensity = lastSum / (float)smoothQueue.Count;

        light.enabled = !light.enabled;
        if (light.enabled)
        {
            gameObject.GetComponent<Renderer>().material = OnMaterial;
            --numFlickerings;
        }
        else gameObject.GetComponent<Renderer>().material = OffMaterial;
    }

    public void StartFlicker() {
        loop = true;
        StartCoroutine(Cooldown());
    }

    public void StopFlicker()
    {
        loop = false;
        
    }
}