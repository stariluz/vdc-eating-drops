using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBehavior : MonoBehaviour
{
    public float speed = 10f;
    new Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.down;
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = speed * rigidbody2D.velocity.normalized;
    }
    public void Destroy(){
        Destroy(gameObject);
    }
}
