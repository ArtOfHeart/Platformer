using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForse;
     public bool Grounded { get; private set;}


    public Rigidbody2D RigidbodyPlayer { get; private set; }
    private SpriteRenderer _spriteRenderer;


    private void Start()
    {
        RigidbodyPlayer = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        Jump();
        IsGrounded();
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {

            if (Grounded)
            {
                RigidbodyPlayer.velocity = new Vector2(RigidbodyPlayer.velocity.x, _jumpForse);

            }
        }
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * _speed;
        RigidbodyPlayer.velocity = new Vector2(moveHorizontal, RigidbodyPlayer.velocity.y);

        if (moveHorizontal > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (moveHorizontal < 0)
        {
            _spriteRenderer.flipX = true;
        }

    }
    private bool IsGrounded()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, 5);

        if (hit.collider != null)
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
        return Grounded;
    }
}
