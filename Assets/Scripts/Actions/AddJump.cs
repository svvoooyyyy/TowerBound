using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddJump : MonoBehaviour
{
    private int _jumpsToAdd = 1;
    private Actions _ac;

    private void Awake()
    {
        _ac = FindObjectOfType<Actions>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _ac.AddJump(_jumpsToAdd);
            Destroy(gameObject);
        }
    }
}
