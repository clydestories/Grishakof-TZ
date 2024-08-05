using System;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private List<KeyCode> _jumpKeys;
    [SerializeField] private List<KeyCode> _shootingKeys;
    [SerializeField] private List<KeyCode> _reloadKeys;

    public event Action Jumped;
    public event Action Shot;
    public event Action Reloaded;
    public event Action<Vector2> Moved;
    public event Action<Vector2> Looked;

    private void Update()
    {
        Vector2 view = new Vector2(Input.GetAxisRaw(MouseX), Input.GetAxisRaw(MouseY)).normalized;
        Looked?.Invoke(view);

        Vector2 movement = new Vector2(Input.GetAxisRaw(Horizontal), Input.GetAxisRaw(Vertical)).normalized;
        Moved.Invoke(movement);

        foreach (KeyCode keyCode in _jumpKeys)
        {
            if (Input.GetKey(keyCode))
            {
                Jumped?.Invoke();
            }
        }

        foreach (KeyCode keyCode in _shootingKeys)
        {
            if (Input.GetKey(keyCode))
            {
                Shot?.Invoke();
            }
        }

        foreach (KeyCode keyCode in _reloadKeys)
        {
            if (Input.GetKey(keyCode))
            {
                Reloaded?.Invoke();
            }
        }
    }
}
