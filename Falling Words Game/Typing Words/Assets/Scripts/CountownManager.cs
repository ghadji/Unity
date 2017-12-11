using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountownManager : MonoBehaviour {

    public Text countdownText;
    private float countdown = 3f;

    void Update() {

        if (countdown > 0) {
            countdown -= Time.deltaTime;
            countdownText.text = Mathf.RoundToInt(countdown).ToString();
        } else {
            SceneManager.LoadScene(1);
        }

    }

}
