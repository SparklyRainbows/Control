using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    #region Movement_vars
    private PlayerMovement Player;
    private Vector2 lastPos;
    private Vector2 curPos;
    [SerializeField]
    [Tooltip("Higher number means slower platform")]
    private float speed;
    [SerializeField]
    [Tooltip("How log to wait upon arival")]
    private float WaitTime;
    public bool is_activated;
    private bool started;
    private bool moving;
    private GameObject lastparent;

    private bool is_column;
    #endregion

    public Transform A;
    public Transform B;
    private Vector2 startPosition;
    private Vector2 endPosition;

    private GameObject player;

    #region Unity_funcs
    private void Awake()
    {
        startPosition = A.position;
        endPosition = B.position;
        
        if (!is_activated)
        {
            moving = true;
            StartCoroutine(Move());
        }
        else
        {
            moving = false;
        }
    }
    #endregion

    #region Movment_funcs
    public void activate()
    {
        StartCoroutine(Move());
    }
    public IEnumerator Move()
    {
        while (true) {
            float progress = 0;

            /*Vector2 targetPos;
            Vector2 originPos;
            if (Vector2.Distance(transform.position, startPosition) > Vector2.Distance(transform.position, endPosition)) {
                targetPos = startPosition;
                originPos = endPosition;
            } else {
                targetPos = endPosition;
                originPos = startPosition;
            }*/

            while (Vector2.Distance(transform.position, startPosition) > Vector2.kEpsilon) {
                if (moving) {
                    Vector2 newPos = Vector3.Lerp(endPosition, startPosition, progress);

                    if (player != null) {
                        Vector2 playerPos = player.transform.position;
                        playerPos += newPos - (Vector2)transform.position;
                        player.transform.position = playerPos;
                    }

                    transform.position = newPos;

                    progress += 1f / speed;
                    yield return null;
                }
            }

            yield return new WaitForSeconds(WaitTime);

            progress = 0;

            while (Vector2.Distance(transform.position, endPosition) > Vector2.kEpsilon) {
                if (moving) {
                    Vector2 newPos = Vector3.Lerp(startPosition, endPosition, progress);

                    if (player != null) {
                        Vector2 playerPos = player.transform.position;
                        playerPos += newPos - (Vector2)transform.position;
                        player.transform.position = playerPos;
                    }

                    transform.position = newPos;

                    progress += 1f / speed;
                    yield return null;
                }
            }

            yield return new WaitForSeconds(WaitTime);
        }

        /*Debug.Log("stared");
        while (true)
        {
            float timer = 0;
            lastPos = transform.position;
            curPos = transform.position;
            while (timer < WaitTime)
            {
                timer += Time.deltaTime;
                yield return null;
                while(moving = false)
                {
                    yield return null;
                }
            }
            while (moving = false)
            {
                yield return null;
            }

            while (transform.position != endPos)
            {
                transform.position = Vector3.Lerp(transform.position, endPos, timer / speed);
                timer += Time.deltaTime;
                curPos = transform.position;
                yield return null;
                lastPos = transform.position;
                while (moving = false)
                {
                    yield return null;
                }
            }
            Vector3 holder = startPos;
            startPos = endPos;
            endPos = holder;
            Debug.Log(endPos);
           
        }*/

    }
    
    #endregion

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            //collision.transform.parent = this.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
            //collision.transform.parent =this.transform.parent.transform.parent.transform.parent;
        }
    }

    #region setter
    public void setStarted(bool B)
    {
        started = B;
    }

    public void setMoving(bool B)
    {
        moving = B;
    }
    #endregion

    #region getter
    public bool getStarted()
    {
        return started;
    }

    public bool getMoving()
    {
        return moving;
    }
    #endregion
}
