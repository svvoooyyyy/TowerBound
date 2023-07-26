using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _speedIncreaseValue;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _timerValue;
    [SerializeField] private float _endPosition;
    private float _speed;
    private float _timer;

    private void Start()
    {
        _speed = _startSpeed;
        _timer = _timerValue;
    }

    private void Update()
    {
        if (_timer <= 0)
        {
            if (_speed < _maxSpeed)
            {
                _speed += _speedIncreaseValue;
            }
            _timer = _timerValue;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (_endPosition > transform.position.y)
        {
            transform.Translate(_speed * Vector3.up * Time.fixedDeltaTime);
        }
    }

    public void SlowDown(float slow)
    {
        _speed = (_speed - slow < 0.0f ? 0.0f : _speed - slow);
    }
}