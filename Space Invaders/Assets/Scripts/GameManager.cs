using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Player player;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    private void Start() {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        Instantiate(player, new Vector3(0, bottomLeft.y - bottomLeft.y / 5, 0), transform.rotation);
    }
}
