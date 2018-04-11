using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTemp : MonoBehaviour {

    public float speed = 3f;
    public GameObject player;
    MenuManager menu;
    public GameObject pausePanel;
    public GameObject UI;
    private bool isPaused = false;
    // Update is called once per frame
    void Update ()
    {
        menu = UI.GetComponent<MenuManager>();
        float postX = Input.GetAxis("Horizontal");
        float PosY = Input.GetAxis("Vertical");

        transform.Translate(postX*speed*Time.deltaTime, 0f, PosY*speed*Time.deltaTime);

        if (Input.GetKeyDown("p"))
        {
            Pause(ref isPaused);
         
        }
        Debug.Log(isPaused);

     
    }

    private void Pause(ref bool isPaused)
    {
        if(isPaused)
        {
            menu.Resume();
            menu.Back(pausePanel);
            isPaused = false;
        }
        else
        {
            menu.Pause();
            menu.ActivatePanel(pausePanel);
            isPaused = true;
        }
    }
}
