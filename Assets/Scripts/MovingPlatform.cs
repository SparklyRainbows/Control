using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    #region Movement_vars
    private Vector3 startPos;
    [SerializeField]
    private Vector3 endPos;
    private PlayerMovement Player;
    private Vector2 lastPos;
    private Vector2 curPos;
    [SerializeField]
    [Tooltip("Higher number means slower platform")]
    private float speed;
    [SerializeField]
    [Tooltip("How log to wait upon arival")]
    private float WaitTime;
    #endregion

    #region Unity_funcs
    private void Awake()
    {
        startPos = transform.position;
        StartCoroutine( Move());
        Debug.Log("stared");

    }
    #endregion

    #region Movment_funcs
    private IEnumerator Move()
    {
        Debug.Log("stared");
        while (true)
        {
            float timer = 0;
            lastPos = transform.position;
            curPos = transform.position;
            while (timer < WaitTime)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            while (transform.position != endPos)
            {
                transform.position = Vector3.Lerp(transform.position, endPos, timer / speed);
                timer += Time.deltaTime;
                curPos = transform.position;
                yield return null;
                lastPos = transform.position;
            }
            Vector3 holder = startPos;
            startPos = endPos;
            endPos = holder;
            Debug.Log(endPos);
            Debug.Log(startPos);
        }

    }
    #endregion

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position += new Vector3( curPos.x - lastPos.x,curPos.y - lastPos.y, 0);
        }
    }
}
