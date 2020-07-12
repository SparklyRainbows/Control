using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Exit");
            StartCoroutine( GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().LoadNextLevel());
        }
    }
}
