using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelectionController : MonoBehaviour {

    public SceneFader sceneFader;
    public string levelToLoad = "MainScene";

    public Text firstPlayerName;
    public int firstPlayerModel = 1;
    public Text secondPlayerName;
    public int secondPlayerModel = 2;

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
        PlayersManager.Instance.firstPlayerModel = firstPlayerModel;
        PlayersManager.Instance.secondPlayerModel = secondPlayerModel;
    }

    public void Back() {
        sceneFader.FadeTo("MainMenu");
    }
}
