using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Missile missile;
    public Transform fire_point;

    public float speed = 5;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Missile m = Instantiate(missile, fire_point.position, missile.transform.rotation);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Alien") {
            GameOver.Instance.EnableGameOver();
        }
    }
}
