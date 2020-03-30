using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    [SerializeField] private float _moveDeltaTime = .1f;

    private FixedJoystick _joystick;
    private float _lastMove;
    private Vector2 _minXY, _maxXY;

    private void Start()
    {
        _joystick = FindObjectOfType<FixedJoystick>();
        _lastMove = Time.time;
        _minXY = GameManager.Instance.MinXY;
        _maxXY = GameManager.Instance.MaxXY;
    }

    private void Update()
    {
        float h = _joystick.Horizontal;
        float v = _joystick.Vertical;

        if ((h != 0 || v != 0) && Time.time - _lastMove > _moveDeltaTime)
        {
            this.transform.position += Vector3.right * _joystick.Horizontal;
            this.transform.position += Vector3.up * _joystick.Vertical;
            _lastMove = Time.time;
        }
        
        FixIfOutOfBounds();
    }

    // If the piece is moved out of the wall bounds
    // it's brought back within
    private void FixIfOutOfBounds()
    {
        foreach (Transform container in this.transform)
        {
            if (container.position.x < _minXY.x) this.transform.position += Vector3.right;
            if (container.position.x > _maxXY.x) this.transform.position -= Vector3.right;
            if (container.position.y < _minXY.y) this.transform.position += Vector3.up;
            if (container.position.y > _maxXY.y) this.transform.position -= Vector3.up;
        }
    }
}
