using System;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _selfDestructDelay;

    private Rigidbody _rigidbody;
    private Coroutine _selfDestruction;
    private float _damage = 0;

    public event Action<Bullet> Destructing;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if (_selfDestruction != null)
        {
            StopCoroutine(_selfDestruction);
        }

        _selfDestruction = StartCoroutine(SeftDestructing());
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

        Destructing?.Invoke(this);
    }

    public void Construct(float damage)
    {
        _damage = damage;
    }

    private IEnumerator SeftDestructing()
    {
        yield return new WaitForSeconds(_selfDestructDelay);
        Destructing?.Invoke(this);
        _selfDestruction = null;
    }
}
