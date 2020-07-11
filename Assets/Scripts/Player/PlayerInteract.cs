using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private GameObject interactable;

    private void Update() {
        if (interactable != null && Input.GetButtonDown("Interact")) {
            interactable.GetComponent<Switch>().Toggle();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Switch")) {
            interactable = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject == interactable) { 
            interactable = null;
        }
    }
}
