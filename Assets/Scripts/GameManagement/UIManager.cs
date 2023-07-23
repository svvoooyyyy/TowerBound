using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _attemptsText;

    [Header("Info")]
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private LevelChanger _levelChanger;

    private void Update()
    {
        _healthText.text = "Health: " + _playerHealth.GetHealth().ToString();
        _attemptsText.text = "Attempts: " + _levelChanger.GetAttempts().ToString();
    }
}
