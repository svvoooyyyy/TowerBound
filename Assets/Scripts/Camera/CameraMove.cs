using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void LateUpdate()
    {
        transform.Translate(_speed * Vector3.up * Time.deltaTime);
    }
}