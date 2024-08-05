using UnityEngine;

public class BulletPool : Pool<Bullet>
{
    private float _nextBulletDamage;

    public BulletPool(Bullet prefab, int defaultCapacity, int maxSize) : base(prefab, defaultCapacity, maxSize) { }

    public Bullet Get(Vector3 position, Vector3 rotation, float damage)
    {
        _nextBulletDamage = damage;
        return base.Get(position, rotation);
    }

    protected override void OnGet(Bullet instance)
    {
        instance.Construct(_nextBulletDamage);
        base.OnGet(instance);
    }
}
