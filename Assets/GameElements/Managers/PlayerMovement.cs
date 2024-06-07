using System.Collections;
using System.Collections.Generic;
using Stariluz.GameLoop;
using UnityEngine;

public class PlayerMovement : GameElementUpdate, IGameElement
{
    new Rigidbody2D rigidbody2D;
    Animator animator;
    public bool isMoving = false;
    public float speed = 2;

    // Start is called before the first frame update
    public override void Start()
    {
        ExecuteUpdate = DisabledUpdate;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void StartGamePlay()
    {
        ExecuteUpdate = RunningUpdate;
    }
    public void StopGamePlay()
    {
        ExecuteUpdate = DisabledUpdate;
        StopMovement();
    }
    private Vector2 savedVelocity;
    public void Pause()
    {
        ExecuteUpdate = PausedUpdate;
        animator.enabled = false;
        savedVelocity = rigidbody2D.velocity;
        rigidbody2D.velocity = new Vector2(0, 0);
    }

    public void Resume()
    {
        animator.enabled = true;
        rigidbody2D.velocity = savedVelocity;
    }


    protected override void RunningUpdate()
    {
        float deltaX = Input.GetAxis("Horizontal");
        if (deltaX == 0)
        {
            isMoving = false;
            StopMovement();
        }
        else
        {
            if (deltaX > 0)
            {
                RightMovement(deltaX);
            }
            else if (deltaX < 0)
            {
                LeftMovement(deltaX);
            }
            isMoving = true;
        }
    }
    protected override void PausedUpdate() { }
    void LeftMovement(float deltaX)
    {
        animator.SetBool("IsMovingLeft", true);
        rigidbody2D.velocity = new Vector2(deltaX * speed, 0);
    }
    void RightMovement(float deltaX)
    {
        animator.SetBool("IsMovingRight", true);
        rigidbody2D.velocity = new Vector2(deltaX * speed, 0);
    }
    void StopMovement()
    {
        animator.SetBool("IsMovingLeft", false);
        animator.SetBool("IsMovingRight", false);
        rigidbody2D.velocity = new Vector2(0, 0);
    }
}
