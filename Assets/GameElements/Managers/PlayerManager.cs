using System;
using UnityEngine;
public class PlayerManager : MonoBehaviour
{
    public MouthCollisionController collisionsController;
    
    [NonSerialized]
    public PlayerMovement movement;

    void Start(){
        movement=GetComponent<PlayerMovement>();
    }
}