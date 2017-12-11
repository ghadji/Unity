using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour {

    public GameObject countdownPanel;

    public void startCountdown() {
        countdownPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
