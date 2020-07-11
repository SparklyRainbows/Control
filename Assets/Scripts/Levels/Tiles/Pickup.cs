using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int left;
    public int right;
    public int jump;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Collect(collision.gameObject);
        }
    }

    private void Collect(GameObject player) {
        player.GetComponent<MovementManager>().Gain(left, right, jump);
        Destroy(gameObject);
    }
}
