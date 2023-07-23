using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Boss : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _startShootingDelay = 4f;
    [SerializeField] private float _shootingDelay = 3f;
    [SerializeField] private Transform _playerPos;

    [Header("AI")]
    [SerializeField] private Transform[] _positions;
    [SerializeField] private float _changeDestinationTime = 10f;
    [SerializeField] private float _moveSpeed;

    private Vector3 _currentDestination;
    private Rigidbody2D _rb;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(ChangeDestination), 0, _changeDestinationTime);
        InvokeRepeating(nameof(shootToPlayer), _startShootingDelay, _shootingDelay);
    }

    private void FixedUpdate()
    {
        _rb.AddForce((_currentDestination - transform.position).normalized * _moveSpeed * Time.fixedDeltaTime);
    }

    private void ChangeDestination() 
    {
        _currentDestination = _positions[Random.Range(0, _positions.Length - 1)].position;
    }

    private void shootToPlayer() 
    {
        _animator.SetTrigger("attack");
        Vector3 diff = (_playerPos.position - transform.position).normalized;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Instantiate(_bullet, transform.position, Quaternion.Euler(new Vector3(0f, 0f, rot_z - 90f)));
        Instantiate(_bullet, transform.position, Quaternion.Euler(new Vector3(0f, 0f, rot_z - 90f + 30f)));
        Instantiate(_bullet, transform.position, Quaternion.Euler(new Vector3(0f, 0f, rot_z - 90f - 30f)));
    }
}
