using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    private LevelChanger _levelChanger;
    [SerializeField] private GameObject _takeDamageParticle;

    private UniversalSoundPlayer _player;
    private void Awake()
    {
        _player = GetComponent<UniversalSoundPlayer>();
        _levelChanger = FindObjectOfType<LevelChanger>();

    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _player.PlayRandomFromIds();
        _currentHealth = (_currentHealth - damage < 0 ? 0 : _currentHealth - damage);
        Instantiate(_takeDamageParticle, transform.position, new Quaternion());
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
