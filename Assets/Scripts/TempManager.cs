using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempManager : MonoBehaviour
{
    #region CheckItems
    [SerializeField]
    private MovementManager Moves;
    #endregion

    #region GameOver_func

    private void is_GameOver()
    {
        if(Moves.getLeftMove() == 0 && Moves.getRightMove() == 0 && Moves.getJumps() == 0)
        {
            Debug.Log("Game Over");
        }
    }
    #endregion

    #region Unity_funcs
    private void Update()
    {
        is_GameOver();
    }
    #endregion
}
