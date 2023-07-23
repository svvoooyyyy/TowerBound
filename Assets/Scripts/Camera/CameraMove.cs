using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _endPosition;

    private void FixedUpdate()
    {
        if (_endPosition > transform.position.y)
        {
            transform.Translate(_speed * Vector3.up * Time.fixedDeltaTime);
        }
    }
}