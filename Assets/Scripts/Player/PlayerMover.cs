using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundCheckHeight;
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private LayerMask _groundCheckLayers;

    private Rigidbody _rigidbody;
    private CapsuleCollider _collider;
    private bool _isGrounded = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
    }

    private void FixedUpdate()
    {
        Vector3 lowestCapsulePoint = _collider.bounds.min - Vector3.up * _groundCheckHeight;

        if (Physics.CapsuleCast(
            _collider.bounds.min, 
            lowestCapsulePoint, 
            _collider.radius, 
            Vector3.down, 
            _groundCheckDistance,
            _groundCheckLayers
            )) 
        { 
            _isGrounded = true;
        }
        
    }

    public void Move(Vector2 direction)
    {
        _rigidbody.velocity = _speed * Time.deltaTime * direction;
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }
}
