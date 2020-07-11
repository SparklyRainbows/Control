using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Trapdoor : MonoBehaviour
{
    public float delay;
    private bool opened;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") && !opened) {
            StartCoroutine(OpenDoor());
        }
    }

    private IEnumerator OpenDoor() {
        opened = true;
        yield return new WaitForSeconds(delay);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
