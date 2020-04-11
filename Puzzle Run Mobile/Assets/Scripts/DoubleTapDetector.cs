using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTapDetector : MonoBehaviour
{
    [SerializeField] private float doubleTapDelta = .25f;

    private float totalFF = 0;
    private bool isFastForwarding = false;

    private bool doubleTap;
    private float lastTap, startFF;

    public float TotalFastForward { get { return totalFF; } }

    public void CheckDoubleTap()
    {
        doubleTap = false;
        
        doubleTap = Time.time - lastTap < doubleTapDelta;
        lastTap = Time.time;

        if (doubleTap)
            FastForward();
    }

    public void StopFastForward()
    {
        if (isFastForwarding)
        {
            isFastForwarding = false;
            totalFF += Time.time - startFF;
            Time.timeScale = 1;
        }
    }

    private void FastForward()
    {
        isFastForwarding = true;
        startFF = Time.time;
        Time.timeScale = GameManager.Instance.SpeedUpScale;
    }
}
