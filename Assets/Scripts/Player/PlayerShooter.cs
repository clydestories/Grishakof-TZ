using System;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public event Action<float, float> BulletsAmountUpdated;

    private void Start()
    {
        BulletsAmountUpdated?.Invoke(_weapon.BulletsInMagazine, _weapon.BulletsInInventory);
    }

    public void Shoot()
    {
        _weapon.Shoot();
        BulletsAmountUpdated?.Invoke(_weapon.BulletsInMagazine, _weapon.BulletsInInventory);
    }

    public void Reload()
    {
        _weapon.Reload();
        BulletsAmountUpdated?.Invoke(_weapon.BulletsInMagazine, _weapon.BulletsInInventory);
    }
}
