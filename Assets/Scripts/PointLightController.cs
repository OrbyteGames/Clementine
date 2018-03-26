using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightController : MonoBehaviour {
 
     Light lightToFade;
    public float eachFadeTime = 2f;
    public float fadeWaitTime = 5f;
    public float MaxDistance = 3f;
    public float minLuminosity = 0f;
    public float maxLuminosity = 3f;
    public float fadeDuration = 3f;
    public LightType type;

    public GameObject clementine;
    bool started;
    void Start()
    {
        started = false;
        lightToFade = GetComponent<Light>();
        lightToFade.intensity = 0;
        lightToFade.type = type;
      
        
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, clementine.transform.position);
        if (distance < MaxDistance && !started)
        {
            started = true;
            StartCoroutine(fadeIn(lightToFade, true, fadeDuration ));
        }
    }
    IEnumerator fadeIn(Light lightToFade, bool fadeIn, float duration)
    {
         // min intensity
       // max intensity

        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;

        if (fadeIn)
        {
            a = minLuminosity;
            b = maxLuminosity;
        }
        else
        {
            a = maxLuminosity;
            b = minLuminosity;
        }

        float currentIntensity = lightToFade.intensity;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            lightToFade.intensity = Mathf.Lerp(a, b, counter / duration);

            yield return null;
        }
    }


    IEnumerator fadeInAndOut(Light lightToFade, bool fadeIn, float duration)
    {
        float minLuminosity = 0; // min intensity
        float maxLuminosity = 1; // max intensity

        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;

        if (fadeIn)
        {
            a = minLuminosity;
            b = maxLuminosity;
        }
        else
        {
            a = maxLuminosity;
            b = minLuminosity;
        }

        float currentIntensity = lightToFade.intensity;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            lightToFade.intensity = Mathf.Lerp(a, b, counter / duration);

            yield return null;
        }
    }

    //Fade in and out forever
    IEnumerator fadeInAndOutRepeat(Light lightToFade, float duration, float waitTime)
    {
        WaitForSeconds waitForXSec = new WaitForSeconds(waitTime);

        while (true)
        {
            //Fade out
            yield return fadeInAndOut(lightToFade, false, duration);

            //Wait
            yield return waitForXSec;

            //Fade-in 
            yield return fadeInAndOut(lightToFade, true, duration);
        }
    }


}
