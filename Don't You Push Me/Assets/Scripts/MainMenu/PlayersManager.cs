using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour {

    public static PlayersManager Instance;

    public string firstPlayerName = "Player1";
    public string secondPlayerName = "Player2";

    public int firstPlayerModel = 1;
    public int secondPlayerModel = 2;

    private void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }
}
