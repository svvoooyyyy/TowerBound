using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBuff : MonoBehaviour
{
    [SerializeField] private float _speedValue;
    [SerializeField] private int _countOfAttempts;
    [SerializeField] private int countOfEnemies;

    private Actions _ac;

    private void Awake()
    {
        _ac = FindObjectOfType<Actions>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _ac.Randomize(_speedValue, countOfEnemies, countOfEnemies);
            Destroy(gameObject);
        }
    }
}
