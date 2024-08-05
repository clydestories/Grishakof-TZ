using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public void Shoot()
    {
        _weapon.Shoot();
    }

    public void Reload()
    {
        _weapon.Reload();
    }
}
