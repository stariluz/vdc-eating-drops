using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAnimationBeginController : MonoBehaviour
{
    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
        animator.Play("Open Screen");
    }
}
