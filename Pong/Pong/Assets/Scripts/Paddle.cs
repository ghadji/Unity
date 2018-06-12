using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float speed;
    public bool isLeft;

    float height;
    string input;

    Vector2 position;

    private void Start() {
        height = transform.localScale.y;
    }

    public void Init(bool isLeft) {
        this.isLeft = isLeft;
        if (isLeft) {
            position = new Vector2(GameManager.bottomLeft.x, 0);
            position += Vector2.right * transform.localScale.x;
            input = "PaddleLeft";
        } else {
            position = new Vector2(GameManager.topRight.x, 0);
            position -= Vector2.right * transform.localScale.x;
            input = "PaddleRight";
        }

        transform.position = position;
        transform.name = input;
    }

    private void Update() {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        //restrict paddle movement
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0) {
            move = 0;
        }

        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0) {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
