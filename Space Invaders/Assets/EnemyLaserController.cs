using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserController : MonoBehaviour {

    public float speed = 3f;

    void FixedUpdate() {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Wall") {
            collision.transform.GetComponent<WallController>().Hit(1);
            Destroy(gameObject);
        }

        if (collision.transform.tag == "Bounds") {
            Destroy(gameObject);
        }

        if (collision.transform.tag == "Player") {
            Destroy(collision.gameObject);

            GameOver.Instance.EnableGameOver();
        }

        if (collision.transform.tag == "Alien" || collision.transform.tag == "Laser") {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.transform.GetComponent<BoxCollider2D>(), true);
        }
    }
}
