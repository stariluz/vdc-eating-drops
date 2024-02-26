using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {}

    public ScoreManager scoreManager;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Edible"))
        {
            scoreManager.RestoreStreak();
            collider.GetComponentInParent<DropBehavior>().Destroy();
        }
        else if(collider.CompareTag("Nasty"))
        {
            collider.GetComponentInParent<DropBehavior>().Destroy();
        }
    }
}
