using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] private GameObject _target;
    private Rigidbody2D _rb;
    private int _currentHealth;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentHealth = _maxHealth;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        _rb.AddForce((_target.transform.position - transform.position).normalized * _moveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    
}
