using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour {

    public void startCountdown() {
        SceneManager.LoadScene(1);
    }

    public void quitGame() {
        Application.Quit();
    }
}
