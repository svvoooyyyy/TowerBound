using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Actions : MonoBehaviour
{
    [SerializeField] private Action[] _actions;
    [SerializeField] private float _speedValue;
    [SerializeField] private int _countOfAttempts;
    [SerializeField] private int countOfEnemies;

    private LevelChanger _levelChanger;
    private PlayerMovement _playerMovement;
    private PlayerCombat _playerCombat;
    private CameraMove _cameraMove;
    private Spawner _spawner;

    private void Awake()
    {
        _levelChanger = FindObjectOfType<LevelChanger>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerCombat = FindObjectOfType<PlayerCombat>();
        _cameraMove = FindObjectOfType<CameraMove>();
        _spawner = FindObjectOfType<Spawner>();
}

    private void Start()
    {
        _actions[0] = AddSpeed;
        _actions[1] = AddAttempts;
        _actions[2] = SpawnEnemies;
    }

    public void AddJump(int add)
    {
        _playerMovement.AddExtraJumps(add);
    }

    public void AddDamage(int add)
    {
        _playerCombat.IncreaseDamage(add);
    }

    public void SlowDownCamera(int slowValue)
    {
        _cameraMove.SlowDown(slowValue);
    }

    public void Randomize()
    {
        int randomIndex = UnityEngine.Random.Range(0, _actions.Length - 1);
        _actions[randomIndex].Invoke();
    }

    private void AddSpeed()
    {
        _playerMovement.AddSpeed(_speedValue);
    }

    private void AddAttempts()
    {
        _levelChanger.AddAttempt(_countOfAttempts);
    }

    private void SpawnEnemies()
    {
        _spawner.SpawnRandomEnemy(countOfEnemies);
    }
}
