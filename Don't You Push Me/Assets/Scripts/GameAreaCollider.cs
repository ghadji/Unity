using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaCollider : MonoBehaviour {

    public GameUI gameUI;
    public SpawnManager spawnManager;

    private void OnTriggerExit(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            MovementController movementController = c.GetComponent<MovementController>();
            Debug.Log("Player " + movementController.m_PlayerNumber + " has lost!");
            gameUI.RoundEnd(movementController.m_PlayerNumber);

            spawnManager.ResetSpawns();
        }
    }
}
