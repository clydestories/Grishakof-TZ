using UnityEngine;
using UnityEngine.Pool;
using Zenject;

public abstract class Pool<T> where T : Component
{
    [Inject] private DiContainer _diContainer;
    private T _prefab;
    private int _defaultCapacity;
    private int _maxSize;
    private ObjectPool<T> _pool;

    private Vector3 _nextSpawnPosition;
    private Vector3 _nextSpawnRotation;

    public Pool(T prefab, int defaultCapacity, int maxSize)
    {
        _prefab = prefab;
        _defaultCapacity = defaultCapacity;
        _maxSize = maxSize;

        _pool = new ObjectPool<T>
            (
                createFunc: OnCreate,
                actionOnGet: OnGet,
                actionOnRelease: OnRelease,
                actionOnDestroy: OnDestroy,
                collectionCheck: true,
                defaultCapacity: _defaultCapacity,
                maxSize: _maxSize

            );
    }

    public virtual T Get(Vector3 position, Vector3 rotation)
    {
        _nextSpawnPosition = position;
        _nextSpawnRotation = rotation;
        return _pool.Get();
    }

    protected virtual void OnGet(T instance)
    {
        instance.transform.position = _nextSpawnPosition;
        instance.transform.rotation = Quaternion.Euler(_nextSpawnRotation);

        if (instance.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }

        instance.gameObject.SetActive(true);
    }

    private T OnCreate()
    {
        return _diContainer.InstantiatePrefab(_prefab).GetComponent<T>();
    }

    private void OnRelease(T instance)
    {
        instance.gameObject.SetActive(false);
    }

    private void OnDestroy(T instance)
    {
        Object.Destroy(instance);
    }
}
