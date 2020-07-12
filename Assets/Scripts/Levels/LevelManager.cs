<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int level;
    public Animator animator;
    public List<GameObject> levelPrefabs;
    private GameObject currentLevel;
    [SerializeField]
    private Canvas C;

    private UI ui;

    private void Start() {
        ui = GameObject.FindGameObjectWithTag("MoveSet").GetComponent<UI>();
        print(ui);
        LoadLevel(level);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            LoadLevel(level);
        }
    }

    public void LoadNextLevel() {
        animator.SetTrigger("fade_out");
        LoadLevel(level + 1);
    }

=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int level;
    public Animator animator;
    public List<GameObject> levelPrefabs;
    private GameObject currentLevel;
    

    private void Start() {
        LoadLevel(level);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            LoadLevel(level);
        }
    }

    public void LoadNextLevel() {
        animator.SetTrigger("fade_out");
        LoadLevel(level + 1);
    }

>>>>>>> 8084e9178b0608af26de781d18a3756a2b183c71
    private void LoadLevel(int num) {
        GameObject.FindGameObjectWithTag("MoveSet").GetComponent<UI>().HideGameOver();

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
