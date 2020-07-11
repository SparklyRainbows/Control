﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int level;

    public List<GameObject> levelPrefabs;
    private GameObject currentLevel;

    private UI ui;

    private void Start() {
        ui = GameObject.FindGameObjectWithTag("MoveSet").GetComponent<UI>();
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
        ui.HideGameOver();

        if (currentLevel != null) {
            Destroy(currentLevel);
        }

        level = num;

        if (num >= levelPrefabs.Count) {
            SceneManager.LoadScene("YouWin");
            return;
        }

        currentLevel = Instantiate(levelPrefabs[level]);
    }
}
