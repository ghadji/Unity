using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed;

    float radius;
    Vector2 direction;

    bool respawning;

    // Use this for initialization
    void Start() {
        respawning = false;
        LaunchBall();
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update() {
        if (!respawning)
            transform.Translate(direction * speed * Time.deltaTime);

        //bounce on top and bottom of screen
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0) {
            direction.y = -direction.y;
        }

        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0) {
            direction.y = -direction.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Paddle") {
            direction.x = -direction.x;
        }
        if (collision.tag == "GoalLeft") {
            GameManager.Instance.IncreaseScoreRight();
            StartCoroutine(ResetBall());
        }
        if (collision.tag == "GoalRight") {
            GameManager.Instance.IncreaseScoreLeft();
            StartCoroutine(ResetBall());
        }
    }

    IEnumerator ResetBall() {
        respawning = true;
        transform.Translate(Vector3.zero);
        transform.position = Vector2.zero;

        yield return new WaitForSeconds(2f);

        LaunchBall();
    }

    void LaunchBall() {
        int randDir = Random.Range(0, 2);
        int randCurve = Random.Range(0, 2);
        if (randDir == 0) {
            if (randCurve == 0)
                direction = Vector2.one.normalized;
            else
                direction = new Vector2(1, -1).normalized;
        } else {
            direction = -Vector2.one.normalized;
            if (randCurve == 0)
                direction = new Vector2(-1, 1).normalized;
            else
                direction = -Vector2.one.normalized;
        }
        respawning = false;
    }
}
