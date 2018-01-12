using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameManager: MonoBehaviour {

    public Camera m_Camera;

    public MovementController movementController;
    public TextMeshPro textMesh;

    private void Start() {
        m_Camera = Camera.main;
        textMesh = GetComponent<TextMeshPro>();

        if (movementController.m_PlayerNumber == 1) {
            textMesh.SetText(PlayersManager.Instance.firstPlayerName);
        } else {
            textMesh.SetText(PlayersManager.Instance.secondPlayerName);
        }

    }

    void Update() {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
