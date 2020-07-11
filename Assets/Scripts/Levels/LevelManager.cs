using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level;

    public List<GameObject> levelPrefabs;
    private GameObject currentLevel;

    private void Start() {
        LoadLevel(1);
    }

    public void LoadNextLevel() {
        LoadLevel(level + 1);
    }

    private void LoadLevel(int num) {
        if (currentLevel != null) {
            Destroy(currentLevel);
        }

        level = num;

        if (num > levelPrefabs.Count) {
            Debug.Log("you win");
            return;
        }

        currentLevel = Instantiate(levelPrefabs[level - 1]);
    }
}
