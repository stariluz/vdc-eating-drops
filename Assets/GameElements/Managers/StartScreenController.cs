
using UnityEngine;

public class ScartScreenControllers : MonoBehaviour
{
    Animator transition;

    void OnEnable(){
        transition.SetTrigger("play");
    }
}