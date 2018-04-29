using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour {

    public WordManager wordManager;
    public float wordDelay = 1.5f;
    private float nextWordTimer = 0f;
    public float spawningIncreaseRate;

    public bool gameEnded = false;

    private void Update() {
        if (!gameEnded)
            if (Time.time >= nextWordTimer) {
                wordManager.addWord();
                nextWordTimer = Time.time + wordDelay;
                wordDelay *= spawningIncreaseRate;
            }
    }

}
