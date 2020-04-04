using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetector : MonoBehaviour
{
    [SerializeField] private float _doubleTapDelta = .25f;

    private float _totalFF = 0;
    private bool _isFastForwarding = false;

    private bool _doubleTap;
    private float _lastTap, _startFF;

    public float TotalFastForward { get { return _totalFF; } }
    public bool IsFastForwarding { get { return _isFastForwarding; } }

    public void CheckDoubleTap()
    {
        _doubleTap = false;
        
        _doubleTap = Time.time - _lastTap < _doubleTapDelta;
        _lastTap = Time.time;

        if (_doubleTap)
            FastForward();
    }

    public void StopFastForward()
    {
        _isFastForwarding = false;
        _totalFF += Time.time - _startFF;
        Time.timeScale = 1;
    }

    private void FastForward()
    {
        _isFastForwarding = true;
        _startFF = Time.time;
        Time.timeScale = GameManager.Instance.SpeedUpScale;
    }
}
