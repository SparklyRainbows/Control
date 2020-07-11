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

    private void LoadLevel(int num) {
        //GameObject.FindGameObjectWithTag("MoveSet").GetComponent<UI>().HideGameOver();

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
