using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(Collider))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundCheckLayers;

    private Rigidbody _rigidbody;
    private Collider _collider;
    private bool _isGrounded = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    public void Move(Vector2 direction)
    {
        Vector3 movementDirection = direction.x * transform.right + direction.y * transform.forward;
        movementDirection *= _speed;
        movementDirection.y = _rigidbody.velocity.y;
        _rigidbody.velocity = movementDirection;
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody.velocity = Vector3.up * _jumpForce;
            _isGrounded = false;
        }
    }

    private void CheckGround()
    {
        RaycastHit[] hits = Physics.CapsuleCastAll
            (
                _collider.bounds.min,
                _collider.bounds.min + Vector3.up,
                _groundCheckRadius,
                Vector3.down,
                _groundCheckDistance,
                _groundCheckLayers
            );

        if (hits.Length > 0)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }
}
