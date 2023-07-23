using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    [SerializeField] private float _startTimerValue;
    private float _timer;
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
    }

    private void Start()
    {
        _timer = _startTimerValue;
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            int randomIndex = Random.Range(0, 2);
            int randomCount = Random.Range(1, 4);

            switch (randomIndex)
            {
                case 0:
                    _spawner.SpawnRandomEnemies(randomCount);
                    break;
                case 1:
                    _spawner.SpawnRandomStuff(randomCount);
                    break;
            }
            _timer = _startTimerValue;
        }
    }
}
