using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _bar;

    private void OnEnable()
    {
        _health.ValueChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= UpdateValue;
    }

    private void UpdateValue(float currentValue, float maxValue)
    {
        _bar.value = currentValue / maxValue;
    }
}
