using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float speed = 5;

    // Update is called once per frame
    void FixedUpdate() {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Alien") {
            Destroy(collision.gameObject);
        }
        
        if (collision.transform.tag == "Laser") {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
