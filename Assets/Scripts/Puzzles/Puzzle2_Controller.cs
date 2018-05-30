using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puzzle2_Controller : MonoBehaviour
{
    public GameObject clementine, container, RobotLight;
    public Transform target, robotTarget;
    Material material;
    public float robotSpeed = 1;
    public float energyIncreaseValue, containerSpeed, timeIncrease;
    public int puzzleTriggerDist;
    public CatAI cat;
    public float storedEnergy;
    private bool startWalking;
    private bool nearActivate = false;
    private float energyTime;
    private AudioSource audioSource;
    public Puzzle2_Animation anim;
    public AudioClip electricSound;
    // Use this for initialization
    void Start()
    {
        storedEnergy = 0.0f;
        energyIncreaseValue = 10.0f;
        RobotLight.SetActive(false);
        material = GetComponent<Renderer>().material;
        audioSource = gameObject.GetComponent<AudioSource>();
        if (electricSound != null && audioSource != null) audioSource.clip = electricSound;
    }

    // Update is called once per frame
    void Update()
    {
        float step = robotSpeed * Time.deltaTime;
        float dist = Vector3.Distance(clementine.transform.position, transform.position);

        if (!startWalking)
        {
            if (dist < puzzleTriggerDist)
            {
                if (!nearActivate)
                {
                    anim.nearActivate();
                    nearActivate = true;
                }
                if (energyTime > 0.0f)
                {
                    energyTime -= Time.deltaTime;
                    gameObject.transform.position += (new Vector3(-robotSpeed, 0.0f, 0.0f) * Time.deltaTime);
                    /*container.transform.position += (new Vector3(-robotSpeed, 0.0f, 0.0f) * Time.deltaTime);*/
                    if (Mathf.Abs(gameObject.transform.position.x - robotTarget.position.x) < 0.1) {
                        startWalking = true;

                    }
                }
                else RobotLight.SetActive(false);
                if (Input.GetButtonDown("Fire1"))
                {
                    anim.active = true;
                    if (electricSound != null && audioSource != null) audioSource.Play();
                    if (!RobotLight.activeSelf) RobotLight.SetActive(true);
                    storedEnergy += energyIncreaseValue;
                    energyTime = timeIncrease;
                }
                if (storedEnergy > 50)
                {
                    RobotLight.SetActive(true);
                    energyTime = 10.0f;
                }
            }
        }
        else
        {
            gameObject.transform.position += (new Vector3(-robotSpeed, 0.0f, 0.0f) * Time.deltaTime);
            container.transform.position += (new Vector3(-containerSpeed, 0.0f, 0.0f) * Time.deltaTime);
            //transform.position += new Vector3(-robotSpeed, 0.0f, 0.0f);
            anim.StopWalking();
            if (Mathf.Abs(container.transform.position.x - target.position.x) < 0.1) Deactivate();
        }

    }


    public void Deactivate()
    {
        startWalking = false;
        anim.solved = true;
        if (cat != null) cat.setSolved();
        enabled = false;
    }
}
