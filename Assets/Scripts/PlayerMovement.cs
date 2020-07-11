using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour {
    private CharacterController2D controller;

    public float runSpeed = 40f;

    private float horizontalMove;
    private bool jump;

    private void Awake() {
        controller = GetComponent<CharacterController2D>();
    }

    private void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }

    private void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}