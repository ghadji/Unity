using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSpawner : MonoBehaviour {

    public GameObject wordPrefab;
    public Transform wordCanvas;

    public float xPos;
    public float yPos;

    public DisplayWord spawnWord() {
        Vector3 randomPos = new Vector3(Random.Range(-xPos, xPos), yPos);

        GameObject wordObject = Instantiate(wordPrefab, randomPos, Quaternion.identity, wordCanvas);

        return wordObject.GetComponent<DisplayWord>();
    }
    


}
