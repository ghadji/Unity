using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public SceneFader sceneFader;
    public string levelToLoad = "CarSelection";

    public Canvas instructionsCanvas;

    private void Awake()
    {
        instructionsCanvas.enabled = false;
    }

    public void StartGame() {
        sceneFader.FadeTo(levelToLoad);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void ShowInstructions()
    {
        instructionsCanvas.enabled = true;
    }

    public void HideInstructions()
    {
        instructionsCanvas.enabled = false;
    }
}
