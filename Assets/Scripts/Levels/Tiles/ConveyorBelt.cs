using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    private float Direction =  1;
    [SerializeField]
    private bool stop;
    [SerializeField]
    private bool stoppable;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !stop)
        {
            collision.gameObject.GetComponent<PlayerMovement>().setHorizontalMove(Speed * Direction);
            Debug.Log(Direction* Speed);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().setHorizontalMove(0f);
        }
    }

    public void changeDirection()
    {
        Direction *= -1;
    }

    public bool getStoppable()
    {
        return stoppable;
    }

    public void changeStop()
    {
        stop = !stop;
    }
}
