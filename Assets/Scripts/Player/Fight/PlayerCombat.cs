using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private int _attackDamage;
    [SerializeField] private float _attackRange;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);
        
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(_attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }

    public void IncreaseDamage(int increase)
    {
        _attackDamage += increase;
    }
}
