using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    [SerializeField] private float _moveDeltaTime = .1f;

    private FixedJoystick _joystick;
    private float _lastMove;

    private void Start()
    {
        _joystick = FindObjectOfType<FixedJoystick>();
        _lastMove = Time.time;
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
        
    }
}
