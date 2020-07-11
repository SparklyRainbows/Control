using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float bounceAmount;

    private float cd = .8f;

    private bool canBounce = true;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            StartCoroutine(Bounce(collision.gameObject));
        }
    }

    private IEnumerator Bounce(GameObject player) {
        if (canBounce && Above(player)) {
            canBounce = false;

            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            Vector2 vel = rb.velocity;
            vel.y = bounceAmount;
            //rb.AddRelativeForce(Vector2.up * bounceAmount);
            rb.velocity = vel;

            yield return new WaitForSeconds(cd);

            canBounce = true;
        }
    }

    private bool Above(GameObject player) {
        return player.transform.position.y - 1 > transform.position.y;
    }
}
