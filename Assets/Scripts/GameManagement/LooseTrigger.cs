using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseTrigger : MonoBehaviour
{
    private GameManager _gm;

    private void Awake()
    {
        _gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _gm.ActivateLoose();
        }
    }
}
