using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
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

    public void AddJump(int add)
    {
        _playerMovement.AddExtraJumps(add);
    }

    public void AddDamage(int add)
    {
        _playerCombat.IncreaseDamage(add);
    }

    public void SlowDownCamera(float slowValue)
    {
        _cameraMove.SlowDown(slowValue);
    }

    public void Randomize(float speedAdd, int attemptsAdd, int enemiesSpawn)
    {
        int indexOfAction = Random.Range(0, 4);

        switch (indexOfAction)
        {
            case 1:
                AddSpeed(speedAdd);
                break;
            case 2:
                AddAttempts(attemptsAdd);
                break;
            case 3:
                SpawnEnemies(enemiesSpawn);
                break;
        }
    }

    private void AddSpeed(float add)
    {
        _playerMovement.AddSpeed(add);
    }

    private void AddAttempts(int add)
    {
        _levelChanger.AddAttempt(add);
    }

    private void SpawnEnemies(int spawn)
    {
        _spawner.SpawnRandomEnemies(spawn);
    }
}
