using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private Weapon _weapon;

    public void Shoot()
    {
        _weapon.Shoot();
    }

    public void Reload()
    {
        _weapon.Reload();
    }
}
