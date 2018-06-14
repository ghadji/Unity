using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour {

    float fireRate = 0.9f;

    public EnemyLaserController laser;

    public int speed = 1;

    private void Start() {
        InvokeRepeating("MoveAlien", 0.5f, 0.5f);
    }

    private void MoveAlien() {

        transform.position += new Vector3(speed, 0f, 0f);
        foreach (Transform e in transform) {
            if (UnityEngine.Random.value >= fireRate) {
                EnemyLaserController l = Instantiate(laser, e.GetChild(0).position, laser.transform.rotation);
            }
        }

        if (transform.position.x >= 4 || transform.position.x <= -3) {
            speed = -speed;
            transform.position += Vector3.down;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {

        if (transform.childCount == 0) {
            GameOver.Instance.EnableWin();
        }

    }
}
