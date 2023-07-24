using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Zombie : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private Transform _groundDetection;
    private Vector3 _direction;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _direction = Vector3.right;
    }

    private void Update()
    {
        _rb.velocity = _direction * _speed;

        RaycastHit2D groundInfo = Physics2D.Raycast(_groundDetection.position, Vector3.down, _distance);

        if (!groundInfo.collider)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _direction.x *= -1;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
