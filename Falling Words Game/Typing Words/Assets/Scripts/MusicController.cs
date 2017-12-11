using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

    public Slider volume;
    public AudioSource sound;

    private void Update() {
        sound.volume = volume.value;
    }

}
