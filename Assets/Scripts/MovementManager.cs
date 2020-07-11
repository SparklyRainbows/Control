﻿using System.Collections;
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
    
    private Canvas Movement;
    #endregion

    #region Unity_funcs

    private void Awake()
    {
        Movement = GameObject.FindGameObjectWithTag("MoveSet").GetComponent<Canvas>();
       
    }
    private void Update()
    {
        TextMeshProUGUI[] Holders = Movement.GetComponentsInChildren<TextMeshProUGUI>();
        Holders[0].text = LeftMove.ToString();
        Holders[1].text = RightMove.ToString();
        Holders[2].text = Jumps.ToString();
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
        Debug.Log("Lowered");
    }

    public void LowerRightMove()
    {
        RightMove -= 1;
        Debug.Log("Lowered");
    }

    public void LowerJumps()
    {
        Jumps -= 1;
        Debug.Log("Lowered");
    }
    #endregion

    public void Gain(int left, int right, int jump) {
        LeftMove += left;
        RightMove += right;
        Jumps += jump;
    }
}
