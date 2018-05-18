 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    public InputController inputController;

    public virtual void Move()
    {
        rb.velocity = (inputController.move * moveSpeed);
    }

    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputController = GetComponent<InputController>();
    }

    public virtual void Update()
    {
        Move();
    }
}
