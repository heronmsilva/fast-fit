using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    private DoubleTapDetector doubleTapDetector;

    private void Awake()
    {
        doubleTapDetector = GetComponent<DoubleTapDetector>();
    }


    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);

        if (background.anchoredPosition != Vector2.zero)
        {
            doubleTapDetector.CheckDoubleTap();
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
    }
}