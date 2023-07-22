using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : MonoBehaviour
{
    private int _damageToIncrease = 10;
    private GameManager _gm;

    private void Awake()
    {
        _gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gm.AddDamage(_damageToIncrease);
            Destroy(gameObject);
        }
    }
}
