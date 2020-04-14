using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    [SerializeField] private float deadzone = 50f;
    [SerializeField] private float doubleTapDelta = .25f;
    [SerializeField] private float longTapDelta = .5f;
    [SerializeField] private RectTransform touchArea = null;
 
    public bool dragPiece = false;
    public bool tapRotate = false;
    public bool doubleTapFF = false;
    public bool longTapFF = false;
    public bool swipeHorizontalFlip = false;
    public bool swipeVerticalFlip = false;

    private float sqrDeadzone, lastTap, startTime;
    private Camera cam;
    private GameManager gm;
    private bool tap, doubleTap, longTap, swipeRight, swipeLeft, swipeUp, swipeDown, drag;
    private Vector2 startTouch, swipeDelta;
    private GameObject toDrag;

    private void Start()
    {
        gm = GameManager.Instance;
        sqrDeadzone = deadzone * deadzone;
        cam = Camera.main;
    }

    private void Update()
    {
        tap = doubleTap = longTap = swipeRight = swipeLeft = swipeDown = swipeUp = false;

        #if UNITY_EDITOR
            CheckMouseInput();    
        #endif

        #if UNITY_ANDROID || UNITY_IOS
            CheckScreenTouch();
        #endif

        if (drag && dragPiece)
        {
            #if UNITY_EDITOR
                Drag(Input.mousePosition);
            #endif
            #if UNITY_ANDROID || UNITY_IOS
                if (Input.touchCount > 0)
                    Drag(Input.GetTouch(0).position);
            #endif
            return;
        }

        if ((swipeLeft || swipeRight) && swipeHorizontalFlip)
        {
            SwipeHorizontalFlip();
            return;
        }

        if ((swipeDown || swipeUp) && swipeVerticalFlip)
        {
            SwipeVerticalFlip();
            return;
        }

        if ((doubleTap && doubleTapFF) || (longTap && longTapFF))
        {
            FastForward();
            return;
        }

        if (tap && tapRotate)
        {
            Rotate();
            return;
        }
    }

    private void CheckMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouch = Input.mousePosition;
            startTime = Time.time;
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(startTouch);
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Piece" && dragPiece)
            {
                toDrag = hit.transform.gameObject;
                drag = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (! drag && RectTransformUtility.RectangleContainsScreenPoint(touchArea, Input.mousePosition))
            {
                tap = true;
                doubleTap = Time.time - lastTap < doubleTapDelta;
                longTap = Time.time - startTime > longTapDelta;
                lastTap = Time.time;
                swipeDelta = (Vector2) Input.mousePosition - startTouch;
            }
            drag = false;
        }

        if (swipeDelta.sqrMagnitude > sqrDeadzone)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }
            swipeDelta = Vector2.zero;
        }
    }

    private void CheckScreenTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouch = touch.position;
                    startTime = Time.time;
                    RaycastHit hit;
                    Ray ray = cam.ScreenPointToRay(startTouch);
                    if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Piece" && dragPiece)
                    {
                        toDrag = hit.transform.gameObject;
                        drag = true;
                    }

                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (! drag && RectTransformUtility.RectangleContainsScreenPoint(touchArea, startTouch))
                    {
                        tap = true;
                        doubleTap = Time.time - lastTap < doubleTapDelta;
                        longTap = Time.time - startTime > longTapDelta;
                        lastTap = Time.time;
                        swipeDelta = (Vector2) touch.position - startTouch;
                    }
                    drag = false;
                    break;
            }

            if (swipeDelta.sqrMagnitude > sqrDeadzone)
            {
                float x = swipeDelta.x;
                float y = swipeDelta.y;

                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x < 0)
                        swipeLeft = true;
                    else
                        swipeRight = true;
                }
                else
                {
                    if (y < 0)
                        swipeDown = true;
                    else
                        swipeUp = true;
                }
                swipeDelta = Vector2.zero;
            }
        }
    }

    private void Drag(Vector2 position)
    {
        if (! toDrag) return;

        float zDistance = toDrag.transform.position.z - cam.transform.position.z;
        Vector3 v3 = new Vector3(position.x, position.y, zDistance);
        v3 = cam.ScreenToWorldPoint(v3);
        toDrag.GetComponent<PieceController>().Translate(v3);
    }

    private void SwipeHorizontalFlip()
    {
        PieceController pieceController = FindObjectOfType<PieceController>();
        pieceController.FlipRight();
    }

    private void SwipeVerticalFlip()
    {
        PieceController pieceController = FindObjectOfType<PieceController>();
        pieceController.FlipUp();
    }

    private void FastForward()
    {
        gm.FastForward();
    }

    private void Rotate()
    {
        PieceController pieceController = FindObjectOfType<PieceController>();
        pieceController.RotateRight();
    }
}
