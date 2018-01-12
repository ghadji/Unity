using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelectionController : MonoBehaviour {

    public SceneFader sceneFader;
    public string levelToLoad = "MainScene";

    public Text firstPlayerName;
    public Text secondPlayerName;

    public Player1_CarSelection carSelection_1;
    public Player2_CarSelection carSelection_2;

    public void StartGame() {
        AssignPlayersNames();
        AssignPlayersModels();


        sceneFader.FadeTo(levelToLoad);
    }

    private void AssignPlayersNames() {
        if (firstPlayerName.text.Equals(""))
            PlayersManager.Instance.firstPlayerName = "Player 1";
        else
            PlayersManager.Instance.firstPlayerName = firstPlayerName.text;

        if (secondPlayerName.text.Equals(""))
            PlayersManager.Instance.secondPlayerName = "Player 2";
        else
            PlayersManager.Instance.secondPlayerName = secondPlayerName.text;
    }

    private void AssignPlayersModels() {
        PlayersManager.Instance.firstPlayerModel = carSelection_1.index;
        PlayersManager.Instance.secondPlayerModel = carSelection_2.index;
    }

    public void Back() {
        sceneFader.FadeTo("MainMenu");
    }
}
