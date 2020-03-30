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
}
