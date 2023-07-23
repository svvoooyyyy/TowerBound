using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownCamera : MonoBehaviour
{
    private int _slowValue;
    private Actions _ac;

    private void Awake()
    {
        _ac = FindObjectOfType<Actions>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _ac.SlowDownCamera(_slowValue);
            Destroy(gameObject);
        }
    }
}