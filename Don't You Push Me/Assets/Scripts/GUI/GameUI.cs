using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour {

    public SceneFader sceneFader;

    string[] discrimiations = { "sad", "miserable", "pitiful", "inadequate", "petty", "useless", "worthless" };

    public int player1_wins = 0;
    public int player2_wins = 0;

    string w;
    string l;

    public TextMeshProUGUI p1_name;
    public TextMeshProUGUI p2_name;

    public TextMeshProUGUI p1_score;
    public TextMeshProUGUI p2_score;

    public Canvas scoreCanvas;
    public Canvas roundFinishCanvas;
    public Canvas goBackToCarSelectionCanvas;

    public TextMeshProUGUI roundFinishMsg;

    MovementController p1_movement;
    MovementController p2_movement;

    private void Awake()
    {
        roundFinishCanvas.enabled = false;
    }

    void Start()
    {
        SetScore();

        roundFinishCanvas.enabled = false;
        goBackToCarSelectionCanvas.enabled = false;

        p1_name.SetText(PlayersManager.Instance.firstPlayerName);
        p2_name.SetText(PlayersManager.Instance.secondPlayerName);

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        p1_movement = gos[0].GetComponent<MovementController>();
        p2_movement = gos[1].GetComponent<MovementController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisableMovement();
            goBackToCarSelectionCanvas.enabled = true;
        }
    }

    public void GoBack()
    {
        sceneFader.FadeTo("CarSelection");
    }

    public void Stay()
    {
        goBackToCarSelectionCanvas.enabled = false;
        EnableMovement();
    }

    public void RoundEnd(int loser)
    {
        if (loser == 1)
        {
            player2_wins++;
            w = PlayersManager.Instance.secondPlayerName;
            l = PlayersManager.Instance.firstPlayerName;
        }
        else
        {
            player1_wins++;
            w = PlayersManager.Instance.firstPlayerName;
            l = PlayersManager.Instance.secondPlayerName;
        }

        SetScore();

        ShowRoundFinishScreen();
    }

    void ShowRoundFinishScreen()
    {
        StartCoroutine(RoundFinishTimer());
    }
	
    IEnumerator RoundFinishTimer()
    {
        roundFinishCanvas.enabled = true;
        roundFinishMsg.SetText(w + " won!\n\n" + l + " you are "+ discrimiations[Random.Range(0, discrimiations.Length-1)] + "...");
        scoreCanvas.enabled = false;
        DisableMovement();
        Debug.Log("before finish");
        yield return new WaitForSeconds(3f);
        Debug.Log("after finish");
        roundFinishCanvas.enabled = false;
        scoreCanvas.enabled = true;
        EnableMovement();
    }

    void SetScore() {
        p1_score.SetText(player1_wins.ToString());
        p2_score.SetText(player2_wins.ToString());
    }

    private void DisableMovement()
    {
        p1_movement.enabled = false;
        p2_movement.enabled = false;
    }

    private void EnableMovement()
    {
        p1_movement.enabled = true;
        p2_movement.enabled = true;
    }
}
