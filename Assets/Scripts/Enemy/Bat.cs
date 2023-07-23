using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bat : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _target;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _target = FindObjectOfType<PlayerMovement>().transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = (_target.transform.position - transform.position).normalized;
        _rb.velocity = direction * _speed;
    }
}
