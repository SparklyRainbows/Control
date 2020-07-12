using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Control pickup;

    public Sprite[] sprites;

    private void OnValidate() {
        GetComponent<SpriteRenderer>().sprite = sprites[(int)pickup];
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Collect(collision.gameObject);
        }
    }

    private void Collect(GameObject player) {
        switch (pickup) {
            case Control.LEFT:
                player.GetComponent<MovementManager>().Gain(1, 0, 0);
                break;
            case Control.RIGHT:
                player.GetComponent<MovementManager>().Gain(0, 1, 0);
                break;
            case Control.JUMP:
                player.GetComponent<MovementManager>().Gain(0, 0, 1);
                break;
        }

        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Pickup");

        Destroy(gameObject);
    }

    [System.Serializable]
    private enum Control {
        LEFT,
        RIGHT,
        JUMP
    }
}


