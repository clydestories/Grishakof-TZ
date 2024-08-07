using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _value;

    public event Action<float, float> ValueChanged;
    public event Action Died;

    public float Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = Mathf.Clamp(value, 0, _maxHealth);
        }
    }

    private void Start()
    {
        Value = _maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Can't take negative damage");
        }

        Value -= amount;
        ValueChanged?.Invoke(Value, _maxHealth);

        if (Value == 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Can't heal negative amount");
        }

        Value += amount;
        ValueChanged?.Invoke(Value, _maxHealth);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
