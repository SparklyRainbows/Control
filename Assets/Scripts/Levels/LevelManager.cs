using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level;

    private void Start() {
        LoadLevel(1);
    }

    public void LoadNextLevel() {
        level++;
    }

    public void LoadLevel(int num) {
        level = num;
    }
}
