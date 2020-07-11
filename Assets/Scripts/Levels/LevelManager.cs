﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level;

    public List<GameObject> levelPrefabs;
    private GameObject currentLevel;
    [SerializeField]
    private Canvas C;

    private void Start() {
        LoadLevel(level);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            LoadLevel(level);
        }
    }

    public void LoadNextLevel() {
        
        LoadLevel(level + 1);
    }

    private void LoadLevel(int num) {
        C.GetComponent<>
        if (currentLevel != null) {
            Destroy(currentLevel);
        }

        level = num;

        if (num >= levelPrefabs.Count) {
            Debug.Log("you win");
            return;
        }

        currentLevel = Instantiate(levelPrefabs[level]);
    }
}
