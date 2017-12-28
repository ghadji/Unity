using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public SceneFader sceneFader;
    public string levelToLoad = "MainScene";

    public void StartGame() {
        sceneFader.FadeTo(levelToLoad);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
