using TMPro;
using UnityEngine;

public class BulletsDisplay : MonoBehaviour
{
    private readonly char _divider = '/';

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private PlayerShooter _shooter;

    private void OnEnable()
    {
        _shooter.BulletsAmountUpdated += UpdateValue;
    }

    private void OnDisable()
    {
        _shooter.BulletsAmountUpdated -= UpdateValue;
    }

    private void UpdateValue(float bulletsInMagazine, float bulletsInInventory)
    {
        _text.text = $"{bulletsInMagazine}{_divider}{bulletsInInventory}";
    }
}
