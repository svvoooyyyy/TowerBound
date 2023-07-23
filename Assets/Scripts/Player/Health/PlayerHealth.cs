using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    private LevelChanger _levelChanger;

    private void Awake()
    {
        _levelChanger = FindObjectOfType<LevelChanger>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
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
        _levelChanger.ActivateLoose();
    }

    public int GetHealth() {
        return _currentHealth;
    }
}
