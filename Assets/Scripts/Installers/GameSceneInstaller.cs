using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _bulletPoolDefaultCapacity;
    [SerializeField] private int _bulletPoolMaxSize;

    public override void InstallBindings()
    {
        Container.Bind<BulletPool>().FromNew().AsSingle().WithArguments(_bulletPrefab, _bulletPoolDefaultCapacity, _bulletPoolMaxSize);
    }
}
