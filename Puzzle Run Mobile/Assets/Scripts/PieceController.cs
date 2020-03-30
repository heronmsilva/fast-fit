using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    private FixedJoystick _joystick;

    private void Start()
    {
        _joystick = FindObjectOfType<FixedJoystick>();
    }

    private void Update()
    {
        this.transform.position += Vector3.right * _joystick.Horizontal;
        this.transform.position += Vector3.up * _joystick.Vertical;
    }
}
