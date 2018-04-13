using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

    public delegate void ButtonAction();
    public Camera associatedCamera;
    public Canvas optionsCanvas;
    public Canvas mainMenuCanvas;
    public StartScript ss;
    public MyButton[] buttons;

    private int buttonIndex;
    private bool optionsOn;
    private bool canvasHidden;

    // Use this for initialization
    void Start () {
        canvasHidden = false;
        optionsOn = false;
        buttonIndex = 0;
        gameObject.GetComponent<Canvas>().worldCamera = associatedCamera;
        buttons = new MyButton[3];
        buttons[0].buttonAction = StartGame;
        buttons[0].button =  GameObject.Find("StartButton");
        buttons[0].image = GameObject.Find("StartButton").GetComponent<Image>();
        buttons[0].image.color = Color.green;

        buttons[1].buttonAction = ToggleOptions;
        buttons[1].button = GameObject.Find("OptionsButton");
        buttons[1].image = GameObject.Find("OptionsButton").GetComponent<Image>();
        buttons[1].image.color = Color.white;

        buttons[2].buttonAction = QuitGame;
        buttons[2].button = GameObject.Find("MainQuitButton");
        buttons[2].image = GameObject.Find("MainQuitButton").GetComponent<Image>();
        buttons[2].image.color = Color.white;

        optionsCanvas.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
        if (!canvasHidden)
        {
            if (!optionsOn)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) && buttonIndex < 2)
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
            else
            {
                if (Input.GetKeyDown(KeyCode.Backspace))
                {
                    optionsOn = false;
                    mainMenuCanvas.gameObject.SetActive(true);
                    optionsCanvas.gameObject.SetActive(false);
                }
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                mainMenuCanvas.gameObject.SetActive(true);
                canvasHidden = false;
            }
        }
    }

    public void StartGame() {
        canvasHidden = true;
        ss.Activate();
        mainMenuCanvas.gameObject.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ToggleOptions()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        optionsCanvas.gameObject.SetActive(true);
        optionsOn = true;
    }



    [System.Serializable]
    public struct MyButton
    {
        public Image image;
        public ButtonAction buttonAction;
        public GameObject button;
    }
}
