using System;
using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private float _damage = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.forward * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyHealth health))
        {
            if (_damage == 0)
            {
                throw new ArgumentException("Damage has not been assigned");
            }

            health.TakeDamage(_damage);
        }
    }

    public void Construct(float damage)
    {
        _damage = damage;
    }
}
