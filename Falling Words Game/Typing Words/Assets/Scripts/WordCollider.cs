using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCollider : MonoBehaviour {

    public GameOverManager gameOverManager;
    public WordManager wordManager;

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("GameOver");
        gameOverManager.transform.gameObject.SetActive(true);
        gameOverManager.gameOver();
    }

    private void OnCollisionExit(Collision collision) {
        Destroy(collision.gameObject);
    }
}
