using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _bulletPoolCapacity;
    [SerializeField] private Bullet _bulletPoolMaxSize;

    public override void InstallBindings()
    {
        
    }
}
