using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(UniversalSoundPlayer))]
public class Enemy : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    [Header("Attack")]
    [SerializeField] private int _attackDamage;
    [SerializeField] private float _startTimeBetweenAttack;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _attackPoint;
    private float _timeBetweenAttack;
    private bool _isAttacking;

    private PlayerHealth _playerHealth;
    private UniversalSoundPlayer _soundPlayer;

    [SerializeField] GameObject _takeDamageParticle;

    private void Awake()
    {
        _soundPlayer = GetComponent<UniversalSoundPlayer>();
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        _isAttacking = Physics2D.OverlapCircle(_attackPoint.position, _attackRange, _playerLayer);

        if (_isAttacking)
        {
            if (_timeBetweenAttack <= 0)
            {
                Attack();
            }
            else
            {
                _timeBetweenAttack -= Time.deltaTime;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _soundPlayer.PlayRandomFromIds();
        Instantiate(_takeDamageParticle, transform.position, new Quaternion());
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        Destroy(gameObject);
    }

    private void Attack()
    {
        _playerHealth.TakeDamage(_attackDamage);
        _timeBetweenAttack = _startTimeBetweenAttack;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
