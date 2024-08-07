using UnityEngine;

public class PlayerLooker : MonoBehaviour
{
    private const float FullRotation = 180;
    private const float MaxPositiveAngle = 360;

    [SerializeField] private Camera _camera;
    [SerializeField] private Player _player;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationX;
    [SerializeField] private float _maxRotationX;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _camera.transform.rotation = Quaternion.identity;
    }

    public void Look(Vector2 direction)
    {
        _player.transform.Rotate(direction.x * Time.deltaTime * _rotationSpeed * Vector3.up);

        _camera.transform.Rotate(-direction.y * Time.deltaTime * _rotationSpeed * Vector3.right);
        Vector3 currentRotation = _camera.transform.rotation.eulerAngles;

        if (currentRotation.x > FullRotation)
        {
            currentRotation.x -= MaxPositiveAngle;
        }

        currentRotation.x = Mathf.Clamp(currentRotation.x, _minRotationX, _maxRotationX);
        _camera.transform.rotation = Quaternion.Euler(currentRotation);
    }
}
