using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public int score;
    public Text scoreText;
    public Text increaseScoreText;

    public Text timer;
    public int totalSecondsPlayed;
    public float time;

    private bool isGameOver = false;

    public void setIsGameOver(bool val) {
        isGameOver = val;
    }

    private void Start() {
        score = 0;
        totalSecondsPlayed = 0;
        timer.text = totalSecondsPlayed + " sec";
        time = 0f;
    }

    private void Update() {
        if (!isGameOver) {
            updateTimer();
        }
    }

    private void updateTimer() {
        time += Time.deltaTime;
        if (time >= 1f) {
            totalSecondsPlayed++;
            timer.text = totalSecondsPlayed.ToString() + " sec";
            time = 0f;
        }
    }

    public void updateScore() {
        StartCoroutine(fadeIncreaseTextToFullAlpha(5f, increaseScoreText));
        score++;
        scoreText.text = score.ToString();
        StartCoroutine(delay());
        StartCoroutine(fadeIncreaseTextToZeroAlpha(2f, increaseScoreText));
    }


    public IEnumerator fadeIncreaseTextToFullAlpha(float t, Text i) {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 0.12f) {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator delay() {
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator fadeIncreaseTextToZeroAlpha(float t, Text i) {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f) {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

}
