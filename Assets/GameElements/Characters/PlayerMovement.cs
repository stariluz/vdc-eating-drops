using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    Animator animator;
    public bool isMoving=false;
    public float speed=2;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX=Input.GetAxis("Horizontal");
        if(deltaX==0){
            isMoving=false;
            StopMoving();
        }else{
            if(deltaX>0){
                RightMovement(deltaX);
            }else if(deltaX<0){
                LeftMovement(deltaX);
            }
            isMoving=true;
        }
    }
    void LeftMovement(float deltaX){
        animator.SetBool("IsMovingLeft", true);
        this.rigidbody2D.velocity=new Vector2(deltaX*speed,0);
    }
    void RightMovement(float deltaX){
        animator.SetBool("IsMovingRight", true);
        this.rigidbody2D.velocity=new Vector2(deltaX*speed,0);
    }
    void StopMoving(){
        animator.SetBool("IsMovingLeft", false);
        animator.SetBool("IsMovingRight", false);
        this.rigidbody2D.velocity=new Vector2(0,0);
    }
}
