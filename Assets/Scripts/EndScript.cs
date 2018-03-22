using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour {

    public delegate void ButtonAction();

    public Camera associatedCamera;
    public Canvas gameOverCanvas;
    public PlayerController pc;
    bool active;
    public MyButton[] buttons;
    private int buttonIndex;
    // Use this for initialization
    void Start () {
        buttonIndex = 0;
        active = false;
        buttons = new MyButton[2];
        buttons[0].buttonAction = Restart;
        buttons[0].button = GameObject.Find("RestartButton");
        buttons[0].image = GameObject.Find("RestartButton").GetComponent<Image>();
        buttons[0].image.color = Color.green;

        buttons[1].buttonAction = Quit;
        buttons[1].button = GameObject.Find("OverQuitButton");
        buttons[1].image = GameObject.Find("OverQuitButton").GetComponent<Image>();
        buttons[1].image.color = Color.white;
        gameOverCanvas.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && buttonIndex < 1)
            {
                buttons[buttonIndex].image.color = Color.white;
                ++buttonIndex;
                buttons[buttonIndex].image.color = Color.green;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && buttonIndex > 0)
            {
                buttons[buttonIndex].image.color = Color.white;
                --buttonIndex;
                buttons[buttonIndex].image.color = Color.green;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                buttons[buttonIndex].buttonAction();
            }

        }
	}

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Entered collider " + gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            pc.PauseCharacter();
            EnableEnd();
            active = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("Left collider " + gameObject.name);
        if (collision.gameObject.tag == "Player")
        {

        }
    }

    public void EnableEnd()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }

    public void SetNewCamera(Camera cam)
    {
        gameObject.GetComponent<Canvas>().worldCamera = cam;
    }


    public void Restart()
    {
         SceneManager.LoadScene("Game");
      
    }

    public void Quit()
    {
        Application.Quit();
    }

    [System.Serializable]
    public struct MyButton
    {
        public Image image;
        public ButtonAction buttonAction;
        public GameObject button;
    }
}
