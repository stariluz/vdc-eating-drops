using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthCollisionController : MonoBehaviour
{
    public delegate void DropEvent(DropController collider2D);
    public DropEvent OnCollisionWithEdibleDrop;
    public DropEvent OnCollisionWithNastyDrop;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.tag);
        if (collider.CompareTag("Edible"))
        {
            OnCollisionWithEdibleDrop?.Invoke(collider.GetComponentInParent<DropController>());
        }
        else if (collider.CompareTag("Nasty"))
        {
            OnCollisionWithNastyDrop?.Invoke(collider.GetComponentInParent<DropController>());
        }
    }
}
