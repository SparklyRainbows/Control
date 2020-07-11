using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI left;
    public TextMeshProUGUI jump;
    public TextMeshProUGUI right;

    public GameObject gameover;

    public void SetText(int l, int j, int r) {
        left.text = l.ToString();
        jump.text = j.ToString();
        right.text = r.ToString();
    }

    public void HideGameOver() {
        gameover.SetActive(false);
    }

    public void ShowGameOver() {
        gameover.SetActive(true);
    }
}
