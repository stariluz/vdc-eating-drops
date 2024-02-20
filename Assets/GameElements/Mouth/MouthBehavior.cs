using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthBehavior : MonoBehaviour
{
    Collider2D colider2D;
    // Start is called before the first frame update
    void Start()
    {
        colider2D = GetComponent<Collider2D>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Edible"))
        {
            // TODO: Logic when an edible is ate.
            
            collider.GetComponentInParent<DropBehavior>().Destroy();
        }
        else if(collider.CompareTag("Nasty"))
        {
            // TODO: Logic when a nasty is ate.
            
            collider.GetComponentInParent<DropBehavior>().Destroy();
        }
    }
}
