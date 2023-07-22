using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBuff : MonoBehaviour
{
    private GameManager _gm;

    private void Awake()
    {
        _gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gm.Randomize();
        }
    }
}
