using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBackToyHorse : MonoBehaviour {

    public Animator animator;
    [Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
    public new Light light;
    public GameObject clementine;
    public float maxDistance = 3f;
    [Tooltip("Minimum random light intensity")]
    public float minIntensity = 0f;
    [Tooltip("Maximum random light intensity")]
    public float maxIntensity = 1f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 50)]
    public int smoothing = 5;
    public ParticleSystem ps;

    private float counter;
    // Music Options
    [Tooltip("Horse,Leitmotiv,Laugh")]
    public AudioSource[] fx;    // Horse Music, Leitmotiv, Laugh
    public float stage1Counter = 2.0f;
    public float stage2Counter = 4.0f;
    public float stage3Counter = 8.0f;
    public float finishCounter = 10.0f;
    public float soundFade = 2.0f;
    public float horseMusicFade = 2.0f;
    public float leitmotivFade = 2.0f;
    public float laughFade = 2.0f;
    
    // ShadowOptions
    public Material matToFade;
    public float shadowFadeIn = 1.0f;
    public float shadowFadeOut = 1.0f;

    // Light Options
    public float lightFade = 2.0f;

    // Continuous average calculation via FIFO queue
    // Saves us iterating every time we update, we just change by the delta
    Queue<float> smoothQueue;
    float lastSum = 0;

    enum FlashBackState { NONE, STAGE1, STAGE2, STAGE3, STAGE4, STAGE5 };
    private FlashBackState actualState;


    // Use this for initialization
    void Start () {
        ps.Stop();
        actualState = FlashBackState.NONE;
        smoothQueue = new Queue<float>(smoothing);
        // External or internal light?
        if (light == null)
        {
            light = gameObject.GetComponent<Light>();
        }
        animator = gameObject.GetComponent<Animator>();
        
    }

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

    // Update is called once per frame
    void Update () {
        if (light == null) return;
        if (actualState != FlashBackState.NONE)
        {
            counter += Time.deltaTime;
            Color currentColor = matToFade.GetColor("_Color");
            switch (actualState)
            {
                case FlashBackState.STAGE1:
                    // shadow fade
                    Debug.Log("Inside stage1");
                    if (light.intensity < 15.0f)
                    {
                        light.intensity += lightFade * Time.deltaTime;
                    }
                    if (currentColor.a < 1.0f)
                    {
                        currentColor.a += Time.deltaTime * (1.0f / shadowFadeIn);
                        matToFade.SetColor("_Color", currentColor);
                    }
                    //currentColor.a = Mathf.Lerp(0.0f, 1.0f, shadowFadeIn);
                    if (counter > 1.0f && ps.isPlaying)
                    {
                        ps.Stop();
                    }
                    if (counter > stage1Counter) {
                        currentColor.a = 1.0f;
                        matToFade.SetColor("_Color", currentColor);
                        actualState = FlashBackState.STAGE2;
                    }
                    break;
                case FlashBackState.STAGE2:                   
                    if (counter > stage2Counter)
                    {
                        if (fx[0].volume > 0)
                        {
                            fx[0].volume -= 2 * Time.deltaTime;
                            if (fx[0].volume  <= 0) fx[0].Stop();
                        }
                        else
                        {
                            fx[1].Play();
                            fx[2].Play();
                            animator.SetBool("startAnim", false);
                            actualState = FlashBackState.STAGE3;
                        }
                    }
                    break;
                case FlashBackState.STAGE3:                   
                    if (counter > stage3Counter)
                    {
                        actualState = FlashBackState.STAGE4;
                    }                   
                    break;
                case FlashBackState.STAGE4:
                    if (currentColor.a > 0.0)
                    {
                        currentColor.a -= Time.deltaTime * (1.0f / shadowFadeOut);
                        matToFade.SetColor("_Color",currentColor);
                    }
                    //currentColor.a = Mathf.Lerp(1.0f, 0.0f, shadowFadeOut);
                    if (fx[2].volume > 0)
                    {
                        fx[2].volume -= laughFade * Time.deltaTime;
                        if (fx[2].volume <= 0) fx[2].Stop();
                    }
                    if (fx[1].volume > 0)
                    {
                        fx[1].volume -= leitmotivFade * Time.deltaTime;
                        if (fx[1].volume <= 0) fx[1].Stop();
                    }
                    if (light.intensity > 0)
                    {
                        light.intensity -= lightFade * Time.deltaTime;   
                    }
                    if (counter > finishCounter)
                    {
                        currentColor.a = 0.0f;
                        matToFade.SetColor("_Color", currentColor);
                        enabled = false;
                        animator.StopPlayback();
                    }
                    break;
            }
        }
    }

   /* IEnumerator Cooldown()
    {
        //Reset Values
        yield return new WaitForSeconds(0.5f);
        Flickering();
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
        light.intensity = lastSum / (float)smoothQueue.Count;
    }*/

    public void StartScene()
    {
        fx[0].Play();
        // fx[3].Play();
        ps.Play();
        animator.SetBool("startAnim", true);
        actualState = FlashBackState.STAGE1;
    }
}
