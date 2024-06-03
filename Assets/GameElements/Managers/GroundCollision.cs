using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    public DropSpawner dropSpawner;
    public ScoreManager scoreManager;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Edible"))
        {
            scoreManager.RestoreStreak();

            dropSpawner.UnregisterDrop(collider.GetComponentInParent<DropLogic>());
        }
        else if (collider.CompareTag("Nasty"))
        
            dropSpawner.UnregisterDrop(collider.GetComponentInParent<DropLogic>());
    }
}
}
