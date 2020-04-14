using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] private GameObject touchControls = null;
    [SerializeField] private GameObject floatingControls = null;
    [SerializeField] private GameObject fixedControls = null;

    private GameManager gm;

    private void Start()
    {
        gm = GetComponent<GameManager>();
        SetupControls();
    }

    private void SetupControls()
    {
        int index = PlayerPrefManager.GetControls();
        string control = GameManager.Controls[index];
        switch (control)
        {
            case "TOUCH":
                SetupTouchControls();
                break;
            case "FLOATING":
                SetupFloatingControls();
                break;
            case "FIXED":
                SetupFixedControls();
                break;
        }
    }

    private void SetupTouchControls()
    {
        floatingControls.SetActive(false);
        fixedControls.SetActive(false);
        
        touchControls.GetComponent<TouchControls>().dragPiece = true;
        touchControls.GetComponent<TouchControls>().tapRotate = true;
        touchControls.GetComponent<TouchControls>().doubleTapFF = false;
        touchControls.GetComponent<TouchControls>().longTapFF = true;
        touchControls.GetComponent<TouchControls>().swipeHorizontalFlip = true;
        touchControls.GetComponent<TouchControls>().swipeVerticalFlip = true;
    }

    private void SetupFloatingControls()
    {
        floatingControls.SetActive(true);
        fixedControls.SetActive(false);
        
        touchControls.GetComponent<TouchControls>().dragPiece = false;
        touchControls.GetComponent<TouchControls>().tapRotate = false;
        touchControls.GetComponent<TouchControls>().doubleTapFF = true;
        touchControls.GetComponent<TouchControls>().longTapFF = false;
        touchControls.GetComponent<TouchControls>().swipeHorizontalFlip = false;
        touchControls.GetComponent<TouchControls>().swipeVerticalFlip = false;
    }

    private void SetupFixedControls()
    {
        fixedControls.SetActive(true);
        floatingControls.SetActive(false);
        
        touchControls.GetComponent<TouchControls>().dragPiece = false;
        touchControls.GetComponent<TouchControls>().tapRotate = false;
        touchControls.GetComponent<TouchControls>().doubleTapFF = true;
        touchControls.GetComponent<TouchControls>().longTapFF = false;
        touchControls.GetComponent<TouchControls>().swipeHorizontalFlip = false;
        touchControls.GetComponent<TouchControls>().swipeVerticalFlip = false;
    }

    public void FlipPieceUp()
    {
        if (gm.IsGameOver || gm.IsPaused) return;

        gm.Piece.GetComponent<PieceController>().FlipUp();
    }

    public void FlipPieceRight()
    {
        if (gm.IsGameOver || gm.IsPaused) return;

        gm.Piece.GetComponent<PieceController>().FlipRight();
    }

    public void RotatePieceLeft()
    {
        if (gm.IsGameOver || gm.IsPaused) return;

        gm.Piece.GetComponent<PieceController>().RotateLeft();
    }

    public void RotatePieceRight()
    {
        if (gm.IsGameOver || gm.IsPaused) return;

        gm.Piece.GetComponent<PieceController>().RotateRight();
    }
}
