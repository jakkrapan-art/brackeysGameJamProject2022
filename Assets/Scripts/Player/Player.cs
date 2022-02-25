using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.5f;
    private GameObject targetObject;
    private Vector2 moveInput;
    private Vector2 playerVelocity;

    private Rigidbody2D rb;
    private Animator animator;

    private bool canMove;
    private float facingDirection; // < 0 = Left, > 0 = Right.
    public Inventory playerInventory { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        playerInventory = GetComponent<Inventory>();

        canMove = true;
        facingDirection = transform.localScale.x / transform.localScale.x;
    }

    private void Update()
    {
        CheckMoveInput();
        UpdatePlayerAnimation();
        Move();
    }

    private void CheckMoveInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (canMove)
        {
            if (facingDirection > 0 && horizontalInput < 0)
            {
                Flip();
            }
            else if (facingDirection < 0 && horizontalInput > 0)
            {
                Flip();
            }
        }

        moveInput.Set(horizontalInput, verticalInput);
    }

    private void UpdatePlayerAnimation()
    {

        if (moveInput.magnitude != 0 && canMove)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void Move()
    {
        if (canMove)
        {
            playerVelocity.Set(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
            rb.velocity = playerVelocity;
        }
    }

    public void EnableMove()
    {
        canMove = true;
    }

    public void DisableMove()
    {
        rb.velocity = Vector2.zero;
        canMove = false;
    }

    private void Flip()
    {
        facingDirection = -facingDirection;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
