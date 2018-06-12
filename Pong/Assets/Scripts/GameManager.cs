using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; set; }
    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    int scoreLeft;
    int scoreRight;
    public Text scoreLeftText;
    public Text scoreRightText;

    // Use this for initialization
    void Start () {
        Instance = this;

        scoreLeft = 0;
        scoreRight = 0;

        scoreLeftText.text = scoreLeft.ToString();
        scoreRightText.text = scoreRight.ToString();

        //convert screen's pixel coordinate into game's coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));

        topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        Instantiate(ball);

        Paddle paddle1 = Instantiate(paddle);
        Paddle paddle2 = Instantiate(paddle);

        //true is left paddle, false is right paddle
        paddle1.Init(true);
        paddle2.Init(false);
	}

    public void IncreaseScoreLeft() {
        scoreLeft++;
        scoreLeftText.text = scoreLeft.ToString();
    }

    public void IncreaseScoreRight() {
        scoreRight++;
        scoreRightText.text = scoreRight.ToString();
    }
}
