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

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
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
        Vector3 target = _camera.ViewportPointToRay(new Vector3(ScreenCenterPercent, ScreenCenterPercent, 0)).GetPoint(MaxShootDistance);
        bullet.transform.LookAt(target);

        _bulletsInMagazine--;
    }

    public void Reload()
    {
        int bulletsToLoad;

        if (_bulletsInInventory <= _maxBulletsInMagazine)
        {
            bulletsToLoad = _bulletsInInventory;
            _bulletsInInventory = 0;
        }
        else
        {
            bulletsToLoad = _maxBulletsInMagazine - _bulletsInMagazine;
            _bulletsInInventory -= bulletsToLoad;
        }

        _bulletsInMagazine += bulletsToLoad;
    }
}
