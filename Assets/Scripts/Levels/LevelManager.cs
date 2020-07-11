using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level;

    private LevelGenerator gen;

    private void Start() {
        gen = GetComponent<LevelGenerator>();
        LoadLevel(1);
    }

    public void LoadNextLevel() {
        LoadLevel(level + 1);
    }

    private void LoadLevel(int num) {
        DestroyLevel();

        level = num;
        gen.GenerateLevel(level);
    }

    private void DestroyLevel() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
}
