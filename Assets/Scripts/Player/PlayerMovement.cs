using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour {
    private CharacterController2D controller;
    private Animator anim;

    public float runSpeed = 40f;

    private float horizontalMove;
    private bool jump;
    private MovementManager moves;
    private float lateset;

    public int slopeDir;
    public float slopeHeight;
    public bool sliding;

    private void Awake() {
        controller = GetComponent<CharacterController2D>();
        moves = GetComponent<MovementManager>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        float x_input = Input.GetAxisRaw("Horizontal");

        if (x_input != Mathf.Sign(horizontalMove) && slopeHeight >= 1 && !sliding) {
            SetSlopeHeight();
            sliding = true;
        }

        if (x_input < 0 && moves.getLeftMove() > 0) {
            if (lateset != 0)
            {
                horizontalMove = lateset;
            }
            else
            {
                horizontalMove = x_input * runSpeed;
            }
            anim.SetBool("moving", true);
        } else if (x_input > 0 && moves.getRightMove() > 0) {
            if (lateset != 0)
            {
                horizontalMove = lateset;
            }
            else
            {
                horizontalMove = x_input * runSpeed;
            }
            anim.SetBool("moving", true);
        } else {
            if (lateset != 0)
            {
                horizontalMove = lateset;
            }
            else
            {
                horizontalMove = 0;
            }
            anim.SetBool("moving", false);
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
            horizontalMove += runSpeed * slopeDir / 3;
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
            Slope s = collision.gameObject.GetComponent<Slope>();
            if (!sliding || s.GetHeight() > slopeHeight || slopeDir != (collision.gameObject.GetComponent<Slope>().facingRight ? 1 : -1)) {
                slopeHeight = collision.gameObject.GetComponent<Slope>().GetHeight();
                slopeDir = collision.gameObject.GetComponent<Slope>().facingRight ? 1 : -1;
            }
        }
    }

    private void ResetSlide() {
        sliding = false;
        slopeHeight = 0;
    }

    private void SetSlopeHeight() {
        slopeHeight -= .25f * slopeHeight;
    }
}