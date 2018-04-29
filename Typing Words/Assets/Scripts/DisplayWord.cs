using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWord : MonoBehaviour {

    public Text text;
    public float fallspeed = 1f;

    private void Start() {
        text = GetComponent<Text>();
    }

    public void setWord(string word) {
        text.text = word;
    }

    public void removeLetter() {
        text.text = text.text.Remove(0,1);
        text.color = Color.red;
    }

    public void removeWord() {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        Destroy(gameObject, 0.3f);
    }

    private void Update() {
        transform.Translate(0, -fallspeed * Time.deltaTime, 0);
    }
}
