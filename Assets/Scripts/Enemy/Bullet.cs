using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _destroyParticle;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.up * _speed * Time.fixedDeltaTime;
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(_damage);
        }
        if (other.gameObject.layer == 6 || other.gameObject.layer == 8)
        {
            Instantiate(_destroyParticle, transform.position, new Quaternion());
            Destroy(gameObject);
        }
    }
}
