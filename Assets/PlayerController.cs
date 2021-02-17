﻿using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public LayerMask gorundLayer;
    public Transform groundChecker;

    public float playerSpeed;
    public float verticalPlayerSpeed = 5;
    public float jumpForce;
    public float fallMultiplier;
    public float lowJumpFallMultiplier;
    public float groundCheckRange = 0.1f;

    bool jumpPressed;
    public bool enableShortJump = true;
    float horizontalMovement;

    private Animator _animator;
    private SpriteRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        fallMultiplier = 2f;
        playerSpeed = 90f;
        _renderer = GetComponentInParent<SpriteRenderer>();
        _animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        BetterFall();
        MovePlayer();
    }

    void CheckInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
        SetAnimation();
    }

    void MovePlayer()
    {
        var yMovement = playerBody.velocity.y;

        if (jumpPressed)
        {
            if (IsGrounded())
            {
                yMovement += jumpForce;
                 _animator.SetBool("jumping", false);
            }

            else
                _animator.SetBool("jumping", true);
        }

        _animator.SetFloat("vertical_speed", yMovement);
        _animator.SetFloat("Speed", Math.Abs(horizontalMovement));
        var playerPosition = horizontalMovement * playerSpeed * Time.deltaTime;
        playerBody.velocity = new Vector2(playerPosition, yMovement);
    }
    public void IsClimbing(bool isClimbing) => _animator.SetBool("climbing", isClimbing);

    void BetterFall()
    {
        // czy nasz player spada?
        if (playerBody.velocity.y < 0 && enableShortJump)
        {
            //fallMultiplier
            playerBody.velocity += Vector2.up * Physics2D.gravity * fallMultiplier * Time.deltaTime;
        }
        // player leci do góry, ale spacja nie jest wciśnięta
        else if (playerBody.velocity.y > 0 && !jumpPressed)
        {
            playerBody.velocity += Vector2.up * Physics2D.gravity * lowJumpFallMultiplier * Time.deltaTime;
            //lowJumpFallMultiplier
        }
    }

    private void SetAnimation()
    {
        _renderer.flipX = horizontalMovement < 0;
        _animator.SetFloat("horizontalSpeed", Math.Abs(horizontalMovement));
    }
    private bool IsGrounded() => Physics2D.OverlapCircle(groundChecker.position, groundCheckRange, gorundLayer) != null;
}
