using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float bounceAmount;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Bounce(collision.gameObject);
        }
    }

    private void Bounce(GameObject player) {
        if (player.GetComponent<CharacterController2D>().IsGrounded()) {
            player.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bounceAmount);
        }
    }
}
