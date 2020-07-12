using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Trapdoor : MonoBehaviour
{
    public float delay;
    public float closeDelay;

    private bool opened;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") && !opened) {
            StartCoroutine(OpenDoor());
        }
    }

    private IEnumerator OpenDoor() {
        opened = true;
        yield return new WaitForSeconds(delay);

        animator.SetBool("Open", true);

        yield return new WaitForSeconds(closeDelay);
        animator.SetBool("Open", false);

        opened = false;
    }
}
