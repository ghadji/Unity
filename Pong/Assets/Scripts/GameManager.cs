using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // Use this for initialization
    void Start () {
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
}
