using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private bool stop;
    [SerializeField]
    private bool stoppable;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        animator.SetBool("stopped", stop);
        animator.SetInteger("direction", (int)Speed);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !stop)
        {
            collision.gameObject.GetComponent<PlayerMovement>().setHorizontalMove(Speed);
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
        Speed *= -1;
        animator.SetInteger("direction", (int)Speed);
    }

    public bool getStoppable()
    {
        return stoppable;
    }

    public void changeStop()
    {
        stop = !stop;
        animator.SetBool("stopped", stop);
    }
}
