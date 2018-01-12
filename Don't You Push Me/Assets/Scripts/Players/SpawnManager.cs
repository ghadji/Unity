using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public Transform spawn_P1;
    public Transform spawn_P2;

    GameObject p1;
    GameObject p2;

    private void Awake() {
        p1 = Instantiate(Resources.Load<GameObject>("Prefabs/PM" + PlayersManager.Instance.firstPlayerModel), spawn_P1);
        p1.GetComponent<MovementController>().m_PlayerNumber = 1;
        p2 = Instantiate(Resources.Load<GameObject>("Prefabs/PM" + PlayersManager.Instance.secondPlayerModel), spawn_P2);
        p2.GetComponent<MovementController>().m_PlayerNumber = 2;
    } 

    public void ResetSpawns()
    {
        p1.transform.SetPositionAndRotation(new Vector3(spawn_P1.position.x, p1.transform.position.y, spawn_P1.position.z), spawn_P1.rotation);

        p2.transform.SetPositionAndRotation(new Vector3(spawn_P2.position.x, p2.transform.position.y, spawn_P2.position.z), spawn_P2.rotation);
    }
}
