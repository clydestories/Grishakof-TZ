using UnityEngine;

public class Weapon : MonoBehaviour
{
    private const float ScreenCenterPercent = 0.5f;

    [SerializeField] private Transform _muzzleEnd;
    [SerializeField] private int _startingBullets;
    [SerializeField] private int _maxBulletsInMagazine;
    [SerializeField] private float _damage;

    private Camera _camera;
    private BulletPool _bulletPool;
    private int _bulletsInMagazine;
    private int _bulletsInInventory;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        _bulletsInInventory = _maxBulletsInMagazine;
        _bulletsInInventory -= _maxBulletsInMagazine;
        _bulletsInMagazine = _maxBulletsInMagazine;
    }

    public void Shoot()
    {
        if (_bulletsInMagazine == 0)
        {
            return;
        }

        Bullet bullet = _bulletPool.Get(_muzzleEnd.position, _muzzleEnd.rotation.eulerAngles);
        Vector3 target = _camera.ViewportToWorldPoint(new Vector3(ScreenCenterPercent, ScreenCenterPercent, 0));
        bullet.transform.LookAt(_camera.ViewportToWorldPoint(target));
    }

    public void Reload()
    {
        if (true)
        {
            _bulletsInInventory -= _maxBulletsInMagazine;
            _bulletsInMagazine = _maxBulletsInMagazine;
        }
    }
}
