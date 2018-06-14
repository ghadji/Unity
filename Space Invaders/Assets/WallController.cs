using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    private int health = 5;

	public void Hit(int damage) {
        if (health - damage <= 0) {
            Die();
            return;
        }
        health -= damage;
    }

    private void Die() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Alien") {
            GameOver.Instance.EnableGameOver();
        }
    }
}
