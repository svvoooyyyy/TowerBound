using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UniversalSoundPlayer))]
public class SlowDownCamera : MonoBehaviour
{
    private int _slowValue;
    private Actions _ac;
    private UniversalSoundPlayer _player;

    private void Awake()
    {
        _player = GetComponent<UniversalSoundPlayer>();
        _ac = FindObjectOfType<Actions>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player.Play(25);
            _ac.SlowDownCamera(_slowValue);
            Destroy(gameObject);
        }
    }
}