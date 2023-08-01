using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int _maxHealth;
    [SerializeField] private GameObject _takeDamageParticle;
    [SerializeField] private float _takingDamageCooldown;
    private float _takingDamageTimer;
    private int _currentHealth;
    private bool _isDied;

    private LevelChanger _levelChanger;
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

    private void Update()
    {
        _takingDamageTimer -= Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        if (_takingDamageTimer <= 0)
        {
            _player.PlayRandomFromIds();
            _currentHealth = (_currentHealth - damage < 0 ? 0 : _currentHealth - damage);
            Instantiate(_takeDamageParticle, transform.position, new Quaternion());
            if (_currentHealth <= 0)
            {
                Die();
            }
            _takingDamageTimer = _takingDamageCooldown;
        }
    }

    private void Die()
    {
        if (!_isDied)
        {
            _levelChanger.ActivateLoose();
            _isDied = true;
        }
    }

    public int GetHealth() {
        return _currentHealth;
    }
}
