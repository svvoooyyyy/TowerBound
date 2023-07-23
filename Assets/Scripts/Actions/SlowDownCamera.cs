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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _ac.SlowDownCamera(_slowValue);
            Destroy(gameObject);
        }
    }
}