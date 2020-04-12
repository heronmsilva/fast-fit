using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    [SerializeField] private float deadzone = 50f;
    [SerializeField] private float doubleTapDelta = .25f;
    [SerializeField] private bool dragPiece = false;
    [SerializeField] private bool tapRotate = false;
    [SerializeField] private bool doubleTapFF = false;
    [SerializeField] private bool swipeUpFF = false;
    [SerializeField] private bool swipeSideFlip = false;
    [SerializeField] private bool swipeDownFlip = false;

    private float sqrDeadzone, lastTap;
    private Camera cam;
    private GameManager gm;
    private bool tap, doubleTap, swipeRight, swipeLeft, swipeUp, swipeDown, drag;
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
        tap = doubleTap = swipeRight = swipeLeft = swipeDown = swipeUp = false;

        #if UNITY_EDITOR
            CheckMouseInput();    
        #endif

        #if UNITY_ANDROID || UNITY_IOS
            CheckScreenTouch();
        #endif

        if (drag && dragPiece)
        {
            #if UNITY_EDITOR
                DragEditor();
            #endif
            #if UNITY_ANDROID || UNITY_IOS
                DragMobile();
            #endif
            return;
        }

        if ((swipeLeft || swipeRight) && swipeSideFlip)
        {
            SwipeSideFlip();
            return;
        }

        if (swipeDown && swipeDownFlip)
        {
            SwipeDownFlip();
            return;
        }

        if ((swipeUp && swipeUpFF) || (doubleTap && doubleTapFF))
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

    private GameObject GetPieceHit(RaycastHit hit)
    {
        Transform t = hit.transform;
        while (t.parent != null)
        {
            if (t.parent.tag == "Piece")
                return t.parent.gameObject;
            t = t.parent.transform;
        }
        return null;
    }

    private void CheckMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouch = Input.mousePosition;
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(startTouch);
            if (Physics.Raycast(ray, out hit) && GetPieceHit(hit))
            {
                toDrag = GetPieceHit(hit);
                drag = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (! drag)
            {
                tap = true;
                doubleTap = Time.time - lastTap < doubleTapDelta;
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

    }

    private void DragEditor()
    {
        if (! toDrag ) return;

        float zDistance = toDrag.transform.position.z - cam.transform.position.z;
        Vector3 v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance);
        v3 = cam.ScreenToWorldPoint(v3);
        toDrag.GetComponent<PieceController>().Translate(v3);
    }

    private void DragMobile()
    {

    }

    private void SwipeSideFlip()
    {
        PieceController pieceController = FindObjectOfType<PieceController>();
        pieceController.FlipRight();
    }

    private void SwipeDownFlip()
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
