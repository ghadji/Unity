﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicSingleton : MonoBehaviour {

    private static BackgroundMusicSingleton instance = null;

    public static BackgroundMusicSingleton Instance {
        get { return instance; }
    }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}