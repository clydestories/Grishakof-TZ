using UnityEngine;

public class PlayerLooker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Player _player;

    public void Look(Vector2 direction)
    {
        _player.transform.Rotate(direction.x * Time.deltaTime * Vector3.up);
        _camera.transform.Rotate(direction.y * Time.deltaTime * Vector3.right);
    }
}
