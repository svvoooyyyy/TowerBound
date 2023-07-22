using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddJump : MonoBehaviour
{
    private int _jumpsToAdd = 1;
    private GameManager _gm;

    private void Awake()
    {
        _gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gm.AddJump(_jumpsToAdd);
            Destroy(gameObject);
        }
    }
}
