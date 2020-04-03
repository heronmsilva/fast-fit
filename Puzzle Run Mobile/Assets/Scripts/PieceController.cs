using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    [SerializeField] private float _moveDeltaTime = .1f;

    private Joystick _joystick;
    private float _lastMove;
    private Vector2 _minXY, _maxXY;
    private float _isFlipped = 1;
    private float _rotationOffset = .1f; // added since rotation slightly changes position

    private void Start()
    {
        _joystick = FindObjectOfType<FixedJoystick>();
        if (! _joystick)
            _joystick = FindObjectOfType<FloatingJoystick>();
            
        _lastMove = Time.time;
        _minXY = GameManager.Instance.MinXY;
        _maxXY = GameManager.Instance.MaxXY;
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver) return;

        if (Time.time - _lastMove > _moveDeltaTime)
        {
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                this.transform.position += Vector3.right * _joystick.Horizontal;
                this.transform.position += Vector3.up * _joystick.Vertical;
                _lastMove = Time.time;
            }
        }
        
        FixIfOutOfBounds();
    }

    public void FlipUp()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        eulerAngles += Vector3.right * 180;
        this.transform.eulerAngles = eulerAngles;
        // Single is inverted in order to
        // rotate in the correct orientation
        // once the piece has been flipped
        _isFlipped = -1 * _isFlipped;
    }

    public void FlipRight()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        eulerAngles += Vector3.up * 180;
        this.transform.eulerAngles = eulerAngles;
        // Single is inverted in order to
        // rotate in the correct orientation
        // once the piece has been flipped
        _isFlipped = -1 * _isFlipped;
    }

    public void RotateLeft()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        eulerAngles += Vector3.forward * 90 * _isFlipped;
        this.transform.eulerAngles = eulerAngles;
    }

    public void RotateRight()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        eulerAngles += Vector3.forward * -90 * _isFlipped;
        this.transform.eulerAngles = eulerAngles;
    }

    // If the piece is moved out of the wall bounds
    // it's brought back within
    private void FixIfOutOfBounds()
    {
        foreach (Transform container in this.transform)
        {
            if (container.position.x < _minXY.x - _rotationOffset) this.transform.position += Vector3.right;
            if (container.position.x > _maxXY.x + _rotationOffset) this.transform.position -= Vector3.right;
            if (container.position.y < _minXY.y - _rotationOffset) this.transform.position += Vector3.up;
            if (container.position.y > _maxXY.y + _rotationOffset) this.transform.position -= Vector3.up;
        }
    }
}
