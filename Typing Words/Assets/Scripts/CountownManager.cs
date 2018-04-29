using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountownManager : MonoBehaviour {

    public Text countdownText;
    private float countdown = 3f;   

    private void Start() {
        StartCoroutine(count());
    }

    IEnumerator count() {
        while (countdown > 0) {
            yield return new WaitForSeconds(1f);
            countdown--;
            countdownText.text = countdown.ToString();
        }
        StartCoroutine(delay());
    }

    IEnumerator delay() {
        countdownText.text = "TYPE";
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }

}
