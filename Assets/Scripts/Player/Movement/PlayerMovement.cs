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
    [SerializeField] private float _checkRadius;
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private LayerMask _groundLayer;
    private bool _isGrounded;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_feetPosition.position, _checkRadius, _groundLayer);

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = _jumpForce * Vector3.up;
        }
    }

    private void FixedUpdate()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector3(_horizontalMove * _speed, _rb.velocity.y);

        if (_isFacingRight && _horizontalMove < 0)
        {
            Flip();
        }
        else  if (!_isFacingRight && _horizontalMove > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
