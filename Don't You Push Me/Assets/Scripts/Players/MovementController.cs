using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovementController : MonoBehaviour {

    public int m_PlayerNumber = 1;              // Used to identify which tank belongs to which player.  This is set by this tank's manager.
    [Header("Movement Variables")]
    public float m_Speed = 12f;                 // How fast the tank moves forward and back.
    public float m_TurnSpeed = 180f;            // How fast the tank turns in degrees per second.

    [Header("Bumping Variables")]
    public float pushForce = 3;

    [HideInInspector] public float m_MovementInputValue;         // The current value of the movement input.
    string m_MovementAxisName;          // The name of the input axis for moving forward and back.
    string m_TurnAxisName;              // The name of the input axis for turning.
    Rigidbody m_Rigidbody;              // Reference used to move the tank.
    float m_TurnInputValue;             // The current value of the turn input.

    private void Awake() {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        // When the tank is turned on, make sure it's not kinematic.
        m_Rigidbody.isKinematic = false;

        // Also reset the input values.
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable() {
        // When the tank is turned off, set it to kinematic so it stops moving.
        m_Rigidbody.isKinematic = true;
    }

    private void Start() {
        // The axes names are based on player number.
        m_MovementAxisName = "Vertical" + m_PlayerNumber;
        m_TurnAxisName = "Horizontal" + m_PlayerNumber;
    }

    private void Update() {
        // Store the value of both input axes.
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);

    }

    private void FixedUpdate() {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();
    }

    private void Move() {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void Turn() {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

    void OnCollisionEnter(Collision c) {
        // If the object we hit is the enemy
        if (c.gameObject.tag == "Player") {

            MovementController mController = c.gameObject.GetComponent<MovementController>();
            Vector3 dir = transform.position - c.transform.position;
            dir.Normalize();

            if (mController.m_MovementInputValue < m_MovementInputValue) {
                c.gameObject.GetComponent<Rigidbody>().AddForce(-dir * pushForce);
            } else if (mController.m_MovementInputValue > m_MovementInputValue) {
                GetComponent<Rigidbody>().AddForce(dir * pushForce);
            }
        }
    }

    private void OnTriggerExit(Collider c) {
        if (c.transform.tag == "GameArea") {
            Debug.Log("Player " + m_PlayerNumber + " has lost!");
        }
    }
}
