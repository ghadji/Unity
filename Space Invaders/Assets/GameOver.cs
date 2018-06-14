using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public static GameOver Instance;

    public GameObject gameOverScreen;
    public GameObject winScreen;

    private void Start() {
        Instance = this;

        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
    }

    public void EnableGameOver() {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void DisableGameOver() {
        Time.timeScale = 0;
        gameOverScreen.SetActive(false);
    }

    public void EnableWin() {
        Time.timeScale = 0;
        winScreen.SetActive(true);
    }

    public void DisableWin() {
        Time.timeScale = 0;
        winScreen.SetActive(false);
    }
}
