using System.Collections;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class NPCController : MonoBehaviour {

    public Transform origin;
    public Transform destination;
    public Material matToFade;
    public float eachFadeTime = 2f;
    public float fadeWaitTime = 5f;
    public float minAlpha = 0f;
    public float maxAlpha = 1f;
    public float fadeDuration = 3f;
   

    public NavMeshAgent agent;
	// Use this for initialization


	void Start ()
    {
        transform.position = origin.position;
        StartCoroutine(fadeInAndOutRepeat(matToFade, fadeDuration, fadeWaitTime));
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

    IEnumerator fadeInAndOut(Material matToFade, bool fadeIn, float duration)
    {
        float minAlpha = 0f; // min intensity
        float maxAlpha = 1f; // max intensity

        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;

        if (fadeIn)
        {
            a = minAlpha;
            b = maxAlpha;
        }
        else
        {
            a = maxAlpha;
            b = minAlpha;
        }

        Color currCol = matToFade.GetColor("_Color");

        while (counter < duration)
        {
            counter += Time.deltaTime;

           currCol.a = Mathf.Lerp(a, b, counter / duration);

            matToFade.SetColor("_Color", currCol);

            yield return null;
        }
    }
    IEnumerator fadeInAndOutRepeat(Material matToFade, float duration, float waitTime)
    {
        WaitForSeconds waitForXSec = new WaitForSeconds(waitTime);

        while (true)
        {
            //Fade out
            yield return fadeInAndOut(matToFade, false, duration);

            //Wait
            yield return waitForXSec;

            //Fade-in 
            yield return fadeInAndOut(matToFade, true, duration);
        }
    }
}
