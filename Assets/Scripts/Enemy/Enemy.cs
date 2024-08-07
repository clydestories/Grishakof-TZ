using UnityEngine;

[RequireComponent (typeof(EnemyHealth), typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private EnemyHealth _health;

    private void Awake()
    {
        _health = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
