using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour {
    private CharacterController2D controller;

    public float runSpeed = 40f;

    private float horizontalMove;
    private bool jump;
    private MovementManager moves;
    private float lateset;

    public float slopeHeight;
    public bool sliding;
    public float slopeMovement;

    private void Awake() {
        controller = GetComponent<CharacterController2D>();
        moves = GetComponent<MovementManager>();
    }

    private void Update() {
        float x_input = Input.GetAxisRaw("Horizontal");

        if (x_input != Mathf.Sign(horizontalMove) && slopeHeight >= 1 && !sliding) {
            sliding = true;
            slopeMovement = -Mathf.Sign(horizontalMove);
        }

        if (x_input < 0 && moves.getLeftMove() > 0) {
            horizontalMove = x_input * runSpeed;
        } else if (x_input > 0 && moves.getRightMove() > 0) {
            horizontalMove = x_input * runSpeed;
        } else {
            if (lateset != 0)
            {
                horizontalMove = lateset;
            }
            else
            {
                horizontalMove = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) {
            moves.LowerRightMove();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) {
            moves.LowerLeftMove();
        }

        if (Input.GetButtonDown("Jump") && moves.getJumps() > 0) {
            jump = true;
            moves.LowerJumps();

            ResetSlide();
        }

        if (slopeHeight <= 0) {
            ResetSlide();
        }
        if (sliding) {
            horizontalMove += runSpeed * slopeMovement / 3;
            slopeHeight -= Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void setHorizontalMove(float speed)
    {
        lateset = speed;
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Slope")) {
            slopeHeight = collision.gameObject.GetComponent<Slope>().GetHeight();
        }
    }

    private void ResetSlide() {
        sliding = false;
        slopeHeight = 0;
    }
}