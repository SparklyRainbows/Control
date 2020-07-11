using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    #region MovmentTrackers
    [SerializeField]
    private int LeftMove;
    [SerializeField]
    private int RightMove;
    [SerializeField]
    private int Jumps;
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
}
