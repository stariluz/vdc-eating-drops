using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stariluz.GameLoop;

public class DropController : MonoBehaviour, IGameElement
{
    public int score = 100;
    public float probability = 0.2f;
    public float speed = 10f;
    new Rigidbody2D rigidbody2D;

    public delegate void DropUpdateFuntion();
    public DropUpdateFuntion DropUpdate;
    // Start is called before the first frame update
    void Start()
    {
        DropUpdate=UpdateMoving;
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.down;
    }

    void FixedUpdate()
    {
        DropUpdate();
    }
    void UpdateMoving()
    {
        rigidbody2D.velocity = speed * rigidbody2D.velocity.normalized;
        rigidbody2D.MoveRotation(0.5f);
    }
    void UpdatePaused()
    {
        rigidbody2D.MoveRotation(0.5f);
    }
    public void Pause()
    {
        DropUpdate=UpdatePaused;
    }
    public void Resume()
    {
        DropUpdate=UpdatePaused;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void StartGamePlay()
    {
        throw new System.NotImplementedException();
    }

    public void StopGamePlay()
    {
        throw new System.NotImplementedException();
    }
}
