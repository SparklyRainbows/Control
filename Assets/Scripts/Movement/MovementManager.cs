using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementManager : MonoBehaviour
{
    #region MovmentTrackers
    [SerializeField]
    private int LeftMove;
    [SerializeField]
    private int RightMove;
    [SerializeField]
    private int Jumps;

    private PlayerInteract interactions;

    private UI ui;
    #endregion

    #region Unity_funcs

    private void Awake()
    {
        interactions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
        ui = GameObject.FindGameObjectWithTag("MoveSet").GetComponent<UI>();
       
    }
    private void Update()
    {
        ui.SetText(LeftMove, Jumps, RightMove);

        if(LeftMove <= 0 && RightMove <= 0 && Jumps <= 0 && !GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().levelEnded)
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Play("Lose");
            ui.ShowGameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Gain(100, 100, 100);
        }
    }

    #endregion

    #region getters
    public int getLeftMove()
    {
        return LeftMove;
    }

    public int getRightMove()
    {
        return RightMove;
    }

    public int getJumps()
    {
        return Jumps;
    }
    #endregion

    #region lower
    public void LowerLeftMove()
    {
        LeftMove-= 1;
        LeftMove = Mathf.Max(0, LeftMove);
    }

    public void LowerRightMove()
    {
        RightMove -= 1;
        RightMove = Mathf.Max(0, RightMove);
    }

    public void LowerJumps()
    {
        Jumps -= 1;
        Jumps = Mathf.Max(0, Jumps);
    }
    #endregion

    public void Gain(int left, int right, int jump) {
        LeftMove += left;
        RightMove += right;
        Jumps += jump;
    }
}
