using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    private const float ScreenCenterPercent = 0.5f;
    private const float MaxShootDistance = 100f;

    [SerializeField] private Transform _muzzleEnd;
    [SerializeField] private int _startingBullets;
    [SerializeField] private int _maxBulletsInMagazine;
    [SerializeField] private float _damage;

    [Inject] private BulletPool _bulletPool;
    private Camera _camera;
    private int _bulletsInMagazine;
    private int _bulletsInInventory;

    public int BulletsInMagazine => _bulletsInMagazine;
    public int BulletsInInventory => _bulletsInInventory;

    private void Awake()
    {
        _camera = Camera.main; 
        _bulletsInInventory = _startingBullets;
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
        bullet.Construct(_damage);
        Vector3 target = _camera.ViewportPointToRay(new Vector3(ScreenCenterPercent, ScreenCenterPercent, 0)).GetPoint(MaxShootDistance);
        bullet.transform.LookAt(target);

        bullet.Destructing += ReleaseBullet;

        _bulletsInMagazine--;
    }

    public void Reload()
    {
        int bulletsToLoad = _maxBulletsInMagazine - _bulletsInMagazine;

        if (_bulletsInInventory <= bulletsToLoad)
        {
            bulletsToLoad = _bulletsInInventory;
            _bulletsInInventory = 0;
        }
        else
        {
            _bulletsInInventory -= bulletsToLoad;
        }

        _bulletsInMagazine += bulletsToLoad;
    }

    private void ReleaseBullet(Bullet bullet)
    {
        bullet.Destructing -= ReleaseBullet;
        _bulletPool.Release(bullet);
    }
}
