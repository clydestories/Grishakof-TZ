using UnityEngine;

[RequireComponent (typeof(Collider))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage * Time.deltaTime);
        }
    }
}
