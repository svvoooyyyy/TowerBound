using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _speedIncreaseValue;
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
            _speed += _speedIncreaseValue;
            _timer = _timerValue;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if (_endPosition > transform.position.y)
        {
            transform.Translate(_speed * Vector3.up * Time.deltaTime);
        }
    }

    public void SlowDown(int slow)
    {
        _speed = (_speed - slow < 0 ? 0 : _speed - slow);
    }
}