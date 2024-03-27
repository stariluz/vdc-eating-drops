using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAnimationController : MonoBehaviour
{
    public Animator nextAnimation;

    public void CallNextAnimation()
    {
        if(nextAnimation!=null){
            nextAnimation.Play("Open Screen");
        }
    }
}
