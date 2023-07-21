using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Walk")]
    [SerializeField] private float _speed;
    private float _horizontalMove;
    private bool _isFacingRight;

    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkGroundRadius;
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private LayerMask _groundLayer;
    private bool _isGrounded;

    [Header("Wall Jump")]
    [SerializeField] private float _xWallForce;
    [SerializeField] private float _yWallForce;
    [SerializeField] private float _wallJumpingDuration;
    private float _wallJumpingDirection;
    private bool _isWallJumping;
    private bool _canWallJump;

    [Header("Wall Sliding")]
    [SerializeField] private float _wallSlidingSpeed;
    [SerializeField] private float _checkWallRadius;
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private LayerMask _wallLayer;
    private bool _isTouchingWall;
    private bool _isWallSliding;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!_isWallJumping) // Freeze the player during the duration of the wall jump
        {
            _rb.velocity = new Vector3(_horizontalMove * _speed, _rb.velocity.y, 0.0f); // Move

            if (_isFacingRight && _horizontalMove > 0) // Turn left
            {
                Flip();
            }
            else if (!_isFacingRight && _horizontalMove < 0) // Turn right
            {
                Flip();
            }
        }
    }
    private void Update()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _isGrounded = Physics2D.OverlapCircle(_feetPosition.position, _checkGroundRadius, _groundLayer); // Check ground

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space)) // Jump
        {
            _rb.velocity = _jumpForce * Vector3.up;
        }

        WallSliding();
        WallJump();
    }

    private void WallSliding() // Wall slide
    {
        _isTouchingWall = Physics2D.OverlapCircle(_wallCheck.position, _checkWallRadius, _wallLayer); // Check wall

        if (_isTouchingWall && !_isGrounded && _horizontalMove != 0)
        {
            _isWallSliding = true;
            _rb.velocity = new Vector3(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y, -_wallSlidingSpeed, float.MaxValue), 0.0f);
        }
        else
        {
            _isWallSliding = false;
        }
    }

    private void WallJump() // Wall jump
    {
        if (_isWallSliding)
        {
            _isWallJumping = false;
            _wallJumpingDirection = -transform.localScale.x;

            CancelInvoke(nameof(StopWallJumping));
        }

        if (_isGrounded)
        {
            _canWallJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isWallSliding && _canWallJump)
        {
            _rb.velocity = new Vector3(_xWallForce * _wallJumpingDirection, _yWallForce, 0.0f);
            _isWallJumping = true;
            _canWallJump = false;

            if (transform.localScale.x != _wallJumpingDirection)
            {
                Flip();
            }

            Invoke(nameof(StopWallJumping), _wallJumpingDuration);
        }
    }

    private void StopWallJumping()  
    {
        _isWallJumping = false;
    }

    private void Flip() // Turn in the opposite direction
    {
        _isFacingRight = !_isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
