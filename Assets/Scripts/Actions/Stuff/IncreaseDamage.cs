using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : MonoBehaviour
{
    private int _damageToIncrease = 10;
    private Actions _ac;

    private void Awake()
    {
        _ac = FindObjectOfType<Actions>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _ac.AddDamage(_damageToIncrease);
            Destroy(gameObject);
        }
    }
}
