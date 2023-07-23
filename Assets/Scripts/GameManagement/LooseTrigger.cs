using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseTrigger : MonoBehaviour
{
    private LevelChanger _levelChanger;

    private void Awake()
    {
        _levelChanger = FindObjectOfType<LevelChanger>().GetComponent<LevelChanger>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _levelChanger.ActivateLoose();
        }
    }
}
