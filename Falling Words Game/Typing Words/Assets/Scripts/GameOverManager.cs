using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public Text finalScoreText;
    public Text showFinalScore;

    public Text finalTotalTime;
    public Text showTotalTime;

    public UIManager uiManager;
    public WordTimer wordTimer;

    public void gameOver() {
        uiManager.setIsGameOver(true);

        wordTimer.gameEnded = true;

        showFinalScore.text = finalScoreText.text;
        showTotalTime.text = finalTotalTime.text;
    }

    public void restartGame() {
        SceneManager.LoadScene(1);
    }

    public void closeGame() {
        Application.Quit();
    }

}
