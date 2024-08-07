using UnityEngine;

[RequireComponent (typeof(PlayerLooker), typeof(PlayerMover), typeof(PlayerShooter))]
[RequireComponent (typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _input;

    private PlayerLooker _looker;
    private PlayerMover _mover;
    private PlayerShooter _shooter;
    private PlayerHealth _health;

    private void Awake()
    {
        _looker = GetComponent<PlayerLooker>();
        _mover = GetComponent<PlayerMover>();
        _shooter = GetComponent<PlayerShooter>();
        _health = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _input.Looked += Look;
        _input.Moved += Move;
        _input.Jumped += Jump;
        _input.Reloaded += Reload;
        _input.Shot += Shoot;
    }

    private void OnDisable()
    {
        _input.Looked -= Look;
        _input.Moved -= Move;
        _input.Jumped -= Jump;
        _input.Reloaded -= Reload;
        _input.Shot -= Shoot;
    }

    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);
    }

    public void Heal(float amount)
    {
        _health.Heal(amount);
    }

    private void Look(Vector2 direction)
    {
        _looker.Look(direction);
    }

    private void Move(Vector2 direction)
    {
        _mover.Move(direction);
    }

    private void Jump()
    {
        _mover.Jump();
    }

    private void Shoot()
    {
        _shooter.Shoot();
    }

    private void Reload()
    {
        _shooter.Reload();
    }
}
